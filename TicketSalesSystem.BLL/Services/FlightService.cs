using AutoMapper;
using TicketSalesSystem.BLL.DTOs;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.DAL.Entities;
using TicketSalesSystem.DAL.Interfaces;

namespace TicketSalesSystem.BLL.Services
{
    internal class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public FlightService(IMapper mapper, IFlightRepository flightRepository, IRouteRepository routeRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
            _routeRepository = routeRepository;
        }

        public Task<FlightDTO> CreateAsync(FlightDTO entity)
        {
            throw new NotImplementedException();
        }
        public Task<FlightDTO> DeleteAsync(FlightDTO entity)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<FlightDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<FlightDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<FlightDTO>(await _flightRepository.GetByIdAsync(id));
        }
        public async Task<IEnumerable<FlightDTO>> GetSearchedFlights(string depPoint, string arrPoint, DateTime depTime)
        {
            var routes = await _routeRepository.GetAllAsync();
            var searchedRoute = routes.FirstOrDefault(r => r.DeparturePoint.ToLower().Equals(depPoint.ToLower()) && r.ArrivalPoint.ToLower().Equals(arrPoint.ToLower()));
            List<Flight> flights = new();
            if (searchedRoute == null) return _mapper.Map<IEnumerable<FlightDTO>>(flights);
            foreach (Flight flight in searchedRoute.Flights)
            {
                if (flight.DepartureTime.Date == depTime.Date) flights.Add(flight);
            }
            return _mapper.Map<IEnumerable<FlightDTO>>(flights);
        }
        public Task<FlightDTO> UpdateAsync(FlightDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
