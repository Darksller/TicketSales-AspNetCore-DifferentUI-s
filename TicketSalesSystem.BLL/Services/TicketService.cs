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
        private readonly IMapper _mapper;
        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<TicketDTO> CreateAsync(TicketDTO entity)
        {
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
