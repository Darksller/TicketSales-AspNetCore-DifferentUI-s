using AutoMapper;
using System.Collections.Generic;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
    internal class SeatTypeService : ISeatTypeService
    {
        private readonly ISeatTypeRepository _seatTypeRepository;
        private readonly IMapper _mapper;

        public SeatTypeService(IMapper mapper, ISeatTypeRepository seatTypeRepository)
        {
            _mapper = mapper;
            _seatTypeRepository = seatTypeRepository;
        }
        public Task<SeatTypeDTO> CreateAsync(SeatTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<SeatTypeDTO> DeleteAsync(SeatTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SeatTypeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SeatTypeDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<SeatTypeDTO>(await _seatTypeRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<SeatTypeDTO>> GetSeatTypesByAirplaneId(int airplaneId)
        {
            var seatTypes = await _seatTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SeatTypeDTO>>(seatTypes.Where(s => s.AirplaneId == airplaneId));
        }

        public Task<SeatTypeDTO> UpdateAsync(SeatTypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
