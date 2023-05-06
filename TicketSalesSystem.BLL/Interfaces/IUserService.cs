using TicketSalesSystem.BLL.DTOs.UserDTOs;

namespace TicketSalesSystem.BLL.Interfaces
{
    public interface IUserService : IBaseService<UserDTO>
    {
        public Task<ResponseUserDTO> Register(RequestUserDTO requestUserDTO);
        public Task<ResponseUserDTO> Login(RequestUserDTO requestUserDTO);
        public Task<ResponseUserDTO> Refresh(string refreshToken);
        public Task<UserDTO> GetByEmailAsync(string email);
        public Task<RefreshTokenDTO> Logout(string refreshToken);

	}
}
