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

            var seatType = await _seatTypeRepository.GetByIdAsync(entity.SeatTypeId);
            if (seatType != null)
            {
                if (seatType.MaxCount - seatType.Tickets.Count() - 1 == 0)
                    return null;
                var mappedEntity = _mapper.Map<Ticket>(entity);
                mappedEntity.User = null;
                mappedEntity.Flight = null;
                mappedEntity.SeatType = null;
                mappedEntity.SeatTypeId = seatType.Id;
                await _ticketRepository.CreateAsync(mappedEntity);
            }

            return entity;
        }
        public async Task<TicketDTO> DeleteAsync(TicketDTO entity)
        {
            var ticket = await _ticketRepository.GetByIdAsync(entity.Id);
            ticket.User = null;
            ticket.Flight = null;
            ticket.SeatType = null;
            await _ticketRepository.DeleteAsync(ticket);

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

        public async Task<IEnumerable<TicketDTO>> GetByUserIdAsync(int userId)
        {
            var tickets = (await _ticketRepository.GetAllAsync()).Where(t => t.UserId == userId).ToList();
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }

        public async Task<IEnumerable<TicketDTO>> GetUnconfirmedAsync()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            var confTick = tickets.Where(t => !t.IsConfirmed).ToList();
            var mappedModel = _mapper.Map<IEnumerable<TicketDTO>>(confTick);
            return mappedModel;
        }
        public async Task<TicketDTO> UpdateAsync(TicketDTO entity)
        {
            var ticket = await _ticketRepository.GetByIdAsync(entity.Id);

            if (ticket == null)
                return null;

            ticket.IsConfirmed = entity.IsConfirmed;
            if (entity.Place != 0)
                ticket.Place = entity.Place;
            if (entity.Price != 0)
                ticket.Price = entity.Price;
            ticket.User = null;
            ticket.Flight = null;
            ticket.SeatType = null;
            await _ticketRepository.UpdateAsync(ticket);

            return entity;
        }
    }
}
