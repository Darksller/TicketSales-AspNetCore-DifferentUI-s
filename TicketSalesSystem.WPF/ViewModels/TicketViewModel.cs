using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicketSalesSystem.BLL.Interfaces;
using TicketSalesSystem.WPF.Configurations;
using TicketSalesSystem.WPF.Models;

namespace TicketSalesSystem.WPF.ViewModels
{
    public class TicketViewModel : INotifyPropertyChanged
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMapper _mapper;
        private readonly ITicketService _ticketService;
        private ObservableCollection<TicketModel> _tickets = new();
        public TicketViewModel()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddWpfMvvmServices(configuration);

            _serviceProvider = serviceCollection.BuildServiceProvider();
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
            _ticketService = _serviceProvider.GetRequiredService<ITicketService>();

            LoadTickets();
        }

        public ObservableCollection<TicketModel> Tickets
        {
            get { return _tickets; }
            set
            {
                if (_tickets != value)
                {
                    _tickets = value;
                    OnPropertyChanged();
                }
            }
        }
        public void LoadTickets()
        {
            Task.Run(() => LoadTicketsAsync());
        }
        public async Task LoadTicketsAsync()
        {
            var tickets = await _ticketService.GetByUserIdAsync(8);
            IEnumerable<TicketModel> ticketsMod = _mapper.Map<IEnumerable<TicketModel>>(tickets);

            Tickets = new ObservableCollection<TicketModel>(ticketsMod);
        }


        private RelayCommand? _bookCommand;
        public RelayCommand BookCommand => _bookCommand ??= new RelayCommand(BookAsync);
        private async void BookAsync(object parameter)
        {
            if (parameter is FlightModel model)
            {
                if (_ticketService == null) return;
                var ticket = await _ticketService.CreateAsync(new BLL.DTOs.TicketDTO { SeatTypeId = model.Airplane.SeatTypes[0].Id, FlightId = model.Id, Price = model.Price, UserId = 8 });
                if (ticket == null) { MessageBox.Show("Все места заняты"); }
                else LoadTickets();
            }
        }

        private RelayCommand? _rejectCommand;
        public RelayCommand RejectCommand => _rejectCommand ??= new RelayCommand(RejectAsync);
        private async void RejectAsync(object parameter)
        {
            if (parameter is TicketModel model)
            {
                if (_ticketService == null) return;
                try
                {
                    await _ticketService.DeleteAsync(new BLL.DTOs.TicketDTO { Id = model.Id });
                    LoadTickets();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Повторите попытку чуть позже:\r\n" + ex);
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
