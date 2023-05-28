using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicketSalesSystem.WPF.Models
{
    public class RouteModel : INotifyPropertyChanged
    {
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _departurePoint = string.Empty;
        public string DeparturePoint
        {
            get => _departurePoint;
            set
            {
                if (_departurePoint != value)
                {
                    _departurePoint = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _arrivalPoint = string.Empty;
        public string ArrivalPoint
        {
            get => _arrivalPoint;
            set
            {
                if (_arrivalPoint != value)
                {
                    _arrivalPoint = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<FlightModel> _flights = new List<FlightModel>();
        public List<FlightModel> Flights
        {
            get => _flights;
            set
            {
                if (_flights != value)
                {
                    _flights = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
