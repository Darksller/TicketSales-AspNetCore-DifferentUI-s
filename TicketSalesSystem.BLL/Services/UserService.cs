using AutoMapper;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TicketSalesSystem.BLL.DTOs.UserDTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.DAL.Entities;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
	internal class UserService : IUserService
	{
		private IUserRepository _userRepository;
		private IMapper _mapper;
		private ILogger<UserService> _logger;
		private ITokenService _tokenService;
		private IRoleRepository _roleRepository;

		public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper, ILogger<UserService> logger, ITokenService tokenService)
		{
			_roleRepository = roleRepository;
			_userRepository = userRepository;
			_mapper = mapper;
			_logger = logger;
			_tokenService = tokenService;
		}
		public async Task<UserDTO> GetByEmailAsync(string email)
		{
			var userChecked = await _userRepository.GetByEmailAsync(email);

			if (userChecked is null)
			{
				_logger.LogError("");
				throw new KeyNotFoundException("");
			}

			var mapperModel = _mapper.Map<UserDTO>(userChecked);

			return mapperModel;
		}

		public async Task<ResponseUserDTO> Login(RequestUserDTO requestUserDTO)
		{
			var userChecked = await _userRepository.GetByEmailAsync(requestUserDTO.Email);

			if (userChecked is null)
			{
				_logger.LogError("This user is not register");
				return null;
			}

			if (!requestUserDTO.Password.Equals(userChecked.Password))
			{
				_logger.LogError("Password is not valid");

				return null;
			}

			var refreshToken = _tokenService.CreateRefreshToken(userChecked.Email);
			refreshToken.UserId = userChecked.Id;
			var oldRefreshToken = await _tokenService.FindTokenByUserId(refreshToken.UserId);

			if (oldRefreshToken.RefreshToken != string.Empty)
				await _tokenService.RemoveAsync(oldRefreshToken);

			await _tokenService.AddAsync(refreshToken);

			var user = _mapper.Map<UserDTO>(userChecked);

			string token = _tokenService.CreateAccessToken(user);

			var userResponse = new ResponseUserDTO()
			{
				Email = user.Email,
				Role = user.Role,
				AccessToken = token,
				RefreshToken = refreshToken.RefreshToken,
				Created = refreshToken.Created,
				Expires = refreshToken.Expires
			};

			return userResponse;
		}

		public async Task<ResponseUserDTO> Register(RequestUserDTO requestUserDTO)
		{
			var userChecked = await _userRepository.GetByEmailAsync(requestUserDTO.Email);

			if (userChecked is not null)
			{
				_logger.LogError("This user is already register");
				return null;
			}

			var mapperModel = _mapper.Map<User>(requestUserDTO);
			mapperModel.Password = requestUserDTO.Password;

			var defaultRole = await _roleRepository.GetByNameAsync("user");

			mapperModel.RoleId = defaultRole.Id;

			await _userRepository.CreateAsync(mapperModel);

			var user = new ResponseUserDTO()
			{
				Email = requestUserDTO.Email,
				Role = defaultRole.Name,
			};

			return user;
		}

		public async Task<ResponseUserDTO> Refresh(string refreshToken)
		{
			await _tokenService.RemoveAsync(new RefreshTokenDTO { RefreshToken = refreshToken });

			var handler = new JwtSecurityTokenHandler();
			var token = handler.ReadJwtToken(refreshToken);

			var userEmail = token.Claims.First(c => c.Type == ClaimTypes.Email).Value;
			var user = await GetByEmailAsync(userEmail);

			var newRefreshToken = _tokenService.CreateRefreshToken(userEmail);
			newRefreshToken.UserId = user.Id;

			await _tokenService.AddAsync(newRefreshToken);

			var accessToken = _tokenService.CreateAccessToken(user);

			var mapperModel = _mapper.Map<ResponseUserDTO>(user);
			mapperModel.RefreshToken = newRefreshToken.RefreshToken;
			mapperModel.Created = newRefreshToken.Created;
			mapperModel.Expires = newRefreshToken.Expires;
			mapperModel.AccessToken = accessToken;

			return mapperModel;
		}
		public async Task<RefreshTokenDTO> Logout(string refreshToken)
		{
			var token = await _tokenService.RemoveAsync(new RefreshTokenDTO
			{
				RefreshToken = refreshToken
			});

			return token;
		}

		public Task<UserDTO> UpdateAsync(UserDTO entity)
		{
			throw new NotImplementedException();
		}
		public Task<UserDTO> CreateAsync(UserDTO entity)
		{
			throw new NotImplementedException();
		}
		public Task<UserDTO> DeleteAsync(UserDTO entity)
		{
			throw new NotImplementedException();
		}
		public Task<IEnumerable<UserDTO>> GetAllAsync()
		{
			throw new NotImplementedException();
		}
		public Task<UserDTO> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}
	}
}
