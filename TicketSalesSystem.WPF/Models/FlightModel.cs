using AutoMapper;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.WPF.Models
{
    public class FlightModel : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _departureTime;
        public DateTime DepartureTime
        {
            get { return _departureTime; }
            set
            {
                if (_departureTime != value)
                {
                    _departureTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _arrivalTime;
        public DateTime ArrivalTime
        {
            get { return _arrivalTime; }
            set
            {
                if (_arrivalTime != value)
                {
                    _arrivalTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _airplaneId;
        public int AirplaneId
        {
            get
            {
                return _airplaneId;
            }
            set
            {
                if (_airplaneId != value)
                {
                    _airplaneId = value;
                    OnPropertyChanged();
                }
            }
        }

        private AirplaneModel? _airplane;
        public AirplaneModel? Airplane
        {
            get => _airplane;
            set
            {
                if (_airplane != value)
                {
                    _airplane = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _flightStatusId;
        public int FlightStatusId
        {
            get { return _flightStatusId; }
            set
            {
                if (_flightStatusId != value)
                {
                    _flightStatusId = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _airlineId;
        public int AirlineId
        {
            get { return _airlineId; }
            set
            {
                if (_airlineId != value)
                {
                    _airlineId = value;
                    OnPropertyChanged();
                }
            }
        }

        private AirlineModel? _airline;
        public AirlineModel? Airline
        {
            get => _airline;
            set
            {
                if (_airline != value)
                {
                    _airline = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _routeId;
        public int RouteId
        {
            get { return _routeId; }
            set
            {
                if (_routeId != value)
                {
                    _routeId = value;
                    OnPropertyChanged();
                }
            }
        }

        private RouteModel? _route;
        public RouteModel? Route
        {
            get => _route;
            set
            {
                if (_route != value)
                {
                    _route = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
