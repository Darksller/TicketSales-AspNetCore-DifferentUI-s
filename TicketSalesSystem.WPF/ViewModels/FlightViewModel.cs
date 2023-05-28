using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.WPF.Configurations;
using TicketSalesSystem.WPF.Models;

namespace TicketSalesSystem.WPF.ViewModels
{
    public class FlightViewModel : INotifyPropertyChanged
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly IFlightService? _flightService;
        private readonly ITicketService? _ticketService;
        private ObservableCollection<FlightModel> _flights = new();
        public FlightViewModel()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddWpfMvvmServices(configuration);

            _serviceProvider = serviceCollection.BuildServiceProvider();
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
            _flightService = _serviceProvider.GetService<IFlightService>();
            _ticketService = _serviceProvider.GetService<ITicketService>();
            LoadFlights();

        }

        public ObservableCollection<FlightModel> Flights
        {
            get { return _flights; }
            set
            {
                if (_flights != value)
                {
                    _flights = value;
                    OnPropertyChanged();
                }
            }
        }
        public void LoadFlights()
        {
            Task.Run(() => LoadFlightsAsync());
        }
        public async Task LoadFlightsAsync()
        {
            if (_flightService != null)
            {
                var fligts = await _flightService.GetAllAsync();
                IEnumerable<FlightModel> flightModels = _mapper.Map<IEnumerable<FlightModel>>(fligts);

                Flights = new ObservableCollection<FlightModel>(flightModels);
            }
        }


        private string? _priceTextBox;
        public string? PriceTextBox
        {
            get { return _priceTextBox; }
            set
            {
                if (_priceTextBox != value)
                {
                    _priceTextBox = value;
                    OnPropertyChanged();
                }
            }
        }

        private string? _flightNumberTextBox;
        public string? FlightNumberTextBox
        {
            get { return _flightNumberTextBox; }
            set
            {
                if (_flightNumberTextBox != value)
                {
                    _flightNumberTextBox = value;
                    OnPropertyChanged();
                }
            }
        }

        private RelayCommand? _sortCommand;
        public RelayCommand SortCommand => _sortCommand ??= new RelayCommand(SortAsync);
        private async void SortAsync(object parameter)
        {
            if (_flightService == null) return;

            var flights = await _flightService.GetAllAsync();

            decimal price;
            if (!string.IsNullOrEmpty(_priceTextBox) && decimal.TryParse(_priceTextBox, out price))
            {
                flights = flights.Where(f => f.Price == decimal.Parse(_priceTextBox)).ToList();
            }

            int number;
            if (!string.IsNullOrEmpty(_flightNumberTextBox) && int.TryParse(_flightNumberTextBox, out number))
            {
                flights = flights.Where(f => f.Id == int.Parse(_flightNumberTextBox)).ToList();
            }

            IEnumerable<FlightModel> flightModels = _mapper.Map<IEnumerable<FlightModel>>(flights);
            Flights = new ObservableCollection<FlightModel>(flightModels);
        }

        private RelayCommand? _resetCommand;
        public RelayCommand ResetCommand => _resetCommand ??= new RelayCommand(ResetAsync);
        private async void ResetAsync(object parameter)
        {
            if (_flightService == null) return;

            var flights = await _flightService.GetAllAsync();

            IEnumerable<FlightModel> flightModels = _mapper.Map<IEnumerable<FlightModel>>(flights);
            Flights = new ObservableCollection<FlightModel>(flightModels);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
