using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TicketSalesSystem.WPF.Models
{
    public class TicketModel : INotifyPropertyChanged
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

        private int _place;
        public int Place
        {
            get => _place;
            set
            {
                if (_place != value)
                {
                    _place = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _userId;
        public int UserId
        {
            get => _userId;
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _flightId;
        public int FlightId
        {
            get => _flightId;
            set
            {
                if (_flightId != value)
                {
                    _flightId = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _seatTypeId;
        public int SeatTypeId
        {
            get => _seatTypeId;
            set
            {
                if (_seatTypeId != value)
                {
                    _seatTypeId = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isConfirmed;
        public bool IsConfirmed
        {
            get => _isConfirmed;
            set
            {
                if (_isConfirmed != value)
                {
                    _isConfirmed = value;
                    OnPropertyChanged();
                }
            }
        }

        private FlightModel? _flight;
        public FlightModel? Flight
        {
            get => _flight;
            set
            {
                if (_flight != value)
                {
                    _flight = value;
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
