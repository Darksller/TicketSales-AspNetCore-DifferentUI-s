using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
    internal class AirplaneService : IAirplaneService
    {
        private readonly IAirplaneRepository _airplaneRepository;
        private readonly IMapper _mapper;

        public AirplaneService(IAirplaneRepository airplaneRepository, IMapper mapper)
        {
            _airplaneRepository = airplaneRepository;
            _mapper = mapper;
        }

        public Task<AirplaneDTO> CreateAsync(AirplaneDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<AirplaneDTO> DeleteAsync(AirplaneDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AirplaneDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AirplaneDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<AirplaneDTO>(await _airplaneRepository.GetByIdAsync(id));
        }

        public Task<AirplaneDTO> UpdateAsync(AirplaneDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
