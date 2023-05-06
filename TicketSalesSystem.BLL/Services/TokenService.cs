using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketSalesSystem.BLL.DTOs.UserDTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.DAL.Entities;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
    internal class TokenService : ITokenService
    {
        private ITokenRepository _tokenRepository;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public TokenService(ITokenRepository tokenRepository, IMapper mapper, IConfiguration configuration)
        {
            _tokenRepository = tokenRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string CreateAccessToken(UserDTO user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var jwt = CreateToken(claims, DateTime.Now.AddMinutes(30));

            return jwt;
        }

        private string CreateToken(List<Claim> claims, DateTime expires)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                   _configuration.GetSection("Secret").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: expires,
                    signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public async Task<RefreshTokenDTO> RemoveAsync(RefreshTokenDTO refreshToken)
        {
            var tokenChecked = await _tokenRepository.GetByTokenAsync(refreshToken.RefreshToken);
            await _tokenRepository.DeleteAsync(tokenChecked);
            return refreshToken;
        }
        public async Task<RefreshTokenDTO> FindToken(string token)
        {
            var tokenChecked = await _tokenRepository.GetByTokenAsync(token);

            if (tokenChecked is null)
            {
                return new RefreshTokenDTO { };
            }

            var mapperModel = _mapper.Map<RefreshTokenDTO>(tokenChecked);

            return mapperModel;
        }
        public async Task<RefreshTokenDTO> AddAsync(RefreshTokenDTO refreshToken)
        {
            var mapperModel = _mapper.Map<Token>(refreshToken);
            await _tokenRepository.CreateAsync(mapperModel);
            return refreshToken;
        }
        public async Task<RefreshTokenDTO> FindTokenByUserId(int id)
        {
            var tokenChecked = await _tokenRepository.GetByUserIdAsync(id);
            if (tokenChecked is null)
            {
                return new RefreshTokenDTO { };
            }
            var mapperModel = _mapper.Map<RefreshTokenDTO>(tokenChecked);
            return mapperModel;
        }
        public RefreshTokenDTO CreateRefreshToken(string email)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email)
            };

            var jwt = CreateToken(claims, DateTime.Now.AddDays(30));

            var refreshToken = new RefreshTokenDTO()
            {
                RefreshToken = jwt,
                Expires = DateTime.Now.AddDays(30),
                Created = DateTime.Now
            };

            return refreshToken;
        }
        public bool ValidateAccessToken(Token token)
        {
            throw new NotImplementedException("");
        }

        public async Task<bool> ValidateRefreshToken(string refreshToken)
        {
            var token = await FindToken(refreshToken);

            //if(token.Expires < DateTime.Now)
            //{
            //    _logger.LogError("Unautorize");
            //    throw new Exceptions.UnauthorizedAccessException("Refresh token is not validation");
            //}

            return true;
        }

    }
}

