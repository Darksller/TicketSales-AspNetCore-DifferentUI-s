using AutoMapper;
using Azure;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
    internal class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public RouteService(IMapper mapper, IRouteRepository routeRepository)
        {
            _mapper = mapper;
            _routeRepository = routeRepository;
        }

        public Task<RouteDTO> CreateAsync(RouteDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<RouteDTO> DeleteAsync(RouteDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RouteDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RouteDTO> GetByIdAsync(int id)
        {
            var entity = await _routeRepository.GetByIdAsync(id);
            var mappedEntity = _mapper.Map<RouteDTO>(entity);
            return mappedEntity;
        }

        public Task<RouteDTO> UpdateAsync(RouteDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
