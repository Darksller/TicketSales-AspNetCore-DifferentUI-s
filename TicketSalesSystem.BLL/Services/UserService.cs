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
        private ITokenService _tokenService;
        private IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper, ITokenService tokenService)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<bool> CheckToken(string refreshToken)
        {

            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(refreshToken);
            var userEmail = token.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var user = await _userRepository.GetByEmailAsync(userEmail);
            var tokenValid = await _tokenService.FindTokenByUserId(user!.Id);
            if (tokenValid.RefreshToken == string.Empty)
            {
                throw new Exception();
            }
            var validate = await _tokenService.ValidateRefreshToken(refreshToken);
            return validate;
        }
        public async Task<ResponseUserDTO> Login(RequestUserDTO requestUserDTO)
        {
            var userChecked = await _userRepository.GetByEmailAsync(requestUserDTO.Email);
            if (userChecked is null) return null;
            if (!requestUserDTO.Password.Equals(userChecked.Password)) return null;

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
            if (userChecked is not null) return null;
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
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(refreshToken);

            var userEmail = token.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var user = await _userRepository.GetByEmailAsync(userEmail);

            if (user is null) return null;

            await _tokenService.RemoveAsync(new RefreshTokenDTO
            {
                RefreshToken = refreshToken,
                UserId = user.Id
            });

            var newRefreshToken = _tokenService.CreateRefreshToken(userEmail);
            newRefreshToken.UserId = user.Id;

            await _tokenService.AddAsync(newRefreshToken);

            var userDto = _mapper.Map<UserDTO>(user);

            var accessToken = _tokenService.CreateAccessToken(userDto);

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
        public async Task<UserDTO> UpdateAsync(UserDTO entity)
        {
            var user = await _userRepository.GetByEmailAsync(entity.Email);
            if (user is null) return null;
            user.Phone = entity.Phone;
            user.Passport = entity.Passport;
            user.Name = entity.Name;
            await _userRepository.UpdateAsync(user);
            return entity;
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
        public async Task<UserDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<UserDTO>(await _userRepository.GetByIdAsync(id));
        }
        public async Task<UserDTO> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            var mappedUser = _mapper.Map<UserDTO>(user);
            return mappedUser;
        }

    }
}
