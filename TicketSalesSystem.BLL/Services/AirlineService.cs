using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
    internal class AirlineService : IAirlineService
    {
        private readonly IAirlineRepository _airlineRepository;
        private readonly IMapper _mapper;

        public AirlineService(IMapper mapper, IAirlineRepository airlineRepository)
        {
            _mapper = mapper;
            _airlineRepository = airlineRepository;
        }
        public Task<AirlineDTO> CreateAsync(AirlineDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<AirlineDTO> DeleteAsync(AirlineDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AirlineDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AirlineDTO> GetByIdAsync(int id)
        {
            var entity = await _airlineRepository.GetByIdAsync(id);
            var mappedEntity = _mapper.Map<AirlineDTO>(entity);
            return mappedEntity;
        }

        public Task<AirlineDTO> UpdateAsync(AirlineDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
