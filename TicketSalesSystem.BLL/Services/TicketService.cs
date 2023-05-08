using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.DAL.Entities;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
    internal class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ISeatTypeRepository _seatTypeRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;
        public TicketService(ITicketRepository ticketRepository, IMapper mapper, ISeatTypeRepository seatTypeRepository, IFlightRepository flightRepository)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
            _seatTypeRepository = seatTypeRepository;
            _flightRepository = flightRepository;
        }

        public async Task<TicketDTO> CreateAsync(TicketDTO entity)
        {
            var tickets = await _ticketRepository.GetByFlightIdAsync(entity.FlightId);
            var flight = await _flightRepository.GetByIdAsync(entity.FlightId);
            var seatTypes = await _seatTypeRepository.GetByAirplaneIdAsync(flight.AirplaneId);
            int i = 0;
            for (; i < seatTypes.Max(s => s.MaxCount) && i < tickets.Count(); i++) ;
            entity.Place = i + 1;
            var seatType = seatTypes.Where(s => s.Id == entity.SeatTypeId).FirstOrDefault();
            seatType.Count -= 1;
            await _seatTypeRepository.UpdateAsync(seatType);
            var mappedEntity = _mapper.Map<Ticket>(entity);
            await _ticketRepository.CreateAsync(mappedEntity);


            return entity;
        }

        public async Task<TicketDTO> DeleteAsync(TicketDTO entity)
        {
            var mappedEntity = _mapper.Map<Ticket>(entity);

            await _ticketRepository.DeleteAsync(mappedEntity);

            return entity;
        }
        public async Task<IEnumerable<TicketDTO>> GetAllAsync()
        {
            var entity = await _ticketRepository.GetAllAsync();
            var mappedEntity = _mapper.Map<IEnumerable<TicketDTO>>(entity);
            return mappedEntity;
        }
        public async Task<TicketDTO> GetByIdAsync(int id)
        {
            var entity = await _ticketRepository.GetByIdAsync(id);
            var mappedEntity = _mapper.Map<TicketDTO>(entity);
            return mappedEntity;
        }
        public async Task<TicketDTO> UpdateAsync(TicketDTO entity)
        {
            var mappedEntity = _mapper.Map<Ticket>(entity);

            await _ticketRepository.UpdateAsync(mappedEntity);

            return entity;
        }
    }
}
