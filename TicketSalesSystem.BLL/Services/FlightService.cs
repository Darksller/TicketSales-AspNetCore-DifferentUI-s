using AutoMapper;
using Microsoft.Extensions.Logging;
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
		private readonly IFlightStatusRepository _flightStatusRepository;
		private readonly IMapper _mapper;

		public FlightService(IMapper mapper, IFlightRepository flightRepository, IRouteRepository routeRepository, IFlightStatusRepository flightStatusRepository)
		{
			_mapper = mapper;
			_flightRepository = flightRepository;
			_routeRepository = routeRepository;
			_flightStatusRepository = flightStatusRepository;
		}

		public Task<FlightDTO> CreateAsync(FlightDTO entity)
		{
			throw new NotImplementedException();
		}
		public Task<FlightDTO> DeleteAsync(FlightDTO entity)
		{
			throw new NotImplementedException();
		}
		public async Task<IEnumerable<FlightDTO>> GetAllAsync()
		{
			var ent = await _flightRepository.GetAllAsync();
			var map = _mapper.Map<IEnumerable<FlightDTO>>(ent);
			return map;
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
		public async Task<FlightDTO> UpdateAsync(FlightDTO entity)
		{

			var existingFlight = await _flightRepository.GetByIdAsync(entity.Id);
			existingFlight.DepartureTime = entity.DepartureTime;
			existingFlight.ArrivalTime = entity.ArrivalTime;
			if (entity.AirplaneId != 0)
				existingFlight.AirplaneId = entity.AirplaneId;
			if (entity.FlightStatusId != 0)
				existingFlight.FlightStatusId = entity.FlightStatusId;
			if (entity.RouteId != 0)
				existingFlight.RouteId = entity.RouteId;
			if (entity.Price != 0)
				existingFlight.Price = entity.Price;
			existingFlight.FlightStatus = null;
			existingFlight.Route = null;
			existingFlight.Airplane = null;
			existingFlight.Tickets = null;
			existingFlight.Airline = null;
			await _flightRepository.UpdateAsync(existingFlight);
			return entity;
		}
	}
}
