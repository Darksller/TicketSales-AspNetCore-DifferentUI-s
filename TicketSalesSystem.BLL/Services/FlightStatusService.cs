using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
    internal class FlightStatusService : IFlightStatusService
    {
        private readonly IFlightStatusRepository _flightStatusRepository;
        private readonly IMapper _mapper;

        public FlightStatusService(IFlightStatusRepository flightStatusRepository, IMapper mapper)
        {
            _flightStatusRepository = flightStatusRepository;
            _mapper = mapper;
        }

        public Task<FlightStatusDTO> CreateAsync(FlightStatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<FlightStatusDTO> DeleteAsync(FlightStatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FlightStatusDTO>> GetAllAsync()
        {
            var ent = await _flightStatusRepository.GetAllAsync();
            var mapped = _mapper.Map<IEnumerable<FlightStatusDTO>>(ent);
            return mapped;
        }

        public async Task<FlightStatusDTO> GetByIdAsync(int id)
        {
            var ent = await _flightStatusRepository.GetByIdAsync(id);
            var mapped = _mapper.Map<FlightStatusDTO>(ent);
            return mapped;
        }

        public Task<FlightStatusDTO> UpdateAsync(FlightStatusDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
