using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSalesSystem.BLL.DTOs.UserDTOs;
using TicketSalesSystem.DAL.Entities;

namespace TicketSalesSystem.BLL.Interfaces
{
    public interface ITokenService
    {
        public string CreateAccessToken(UserDTO user);
        public RefreshTokenDTO CreateRefreshToken(string email);
        public bool ValidateAccessToken(Token token);
        public Task<bool> ValidateRefreshToken(string refreshToken);
        public Task<RefreshTokenDTO> AddAsync(RefreshTokenDTO refreshToken);
        public Task<RefreshTokenDTO> RemoveAsync(RefreshTokenDTO refreshToken);
        public Task<RefreshTokenDTO> FindToken(string token);
        public Task<RefreshTokenDTO> FindTokenByUserId(int id);
    }
}
