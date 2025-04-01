using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using SGBDJeremy.DAL.Interfaces;
using SGBDJeremy.DAL.Repositories;
using SGBDJeremy.Models;
using SGBDJeremy.Utilities.Data;

namespace SGBDJeremy.ViewModels
{
    public class ClientHomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public int ConnectedClientId { get; set; }

        public ObservableCollection<Meeting> ClientMeetings { get; set; } = new();
        public ObservableCollection<Meeting> PastMeetings { get; set; } = new();

        public ObservableCollection<Service> Services { get; set; } = new();
        public ObservableCollection<Employee> Employees { get; set; } = new();

        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set { _selectedDate = value; OnPropertyChanged(); }
        }

        private TimeSpan _selectedTime = TimeSpan.FromHours(9);
        public TimeSpan SelectedTime
        {
            get => _selectedTime;
            set { _selectedTime = value; OnPropertyChanged(); }
        }

        private Service _selectedService;
        public Service SelectedService
        {
            get => _selectedService;
            set { _selectedService = value; OnPropertyChanged(); }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set { _selectedEmployee = value; OnPropertyChanged(); }
        }

        public ICommand BookMeetingCommand { get; }

        private readonly IMeetingRepository _meetingRepository;

        public ClientHomeViewModel(int clientId, IMeetingRepository meetingRepository = null)
        {
            ConnectedClientId = clientId;
            _meetingRepository = meetingRepository;
            BookMeetingCommand = new Command(OnBookMeeting);

            LoadServices();
            LoadEmployees();
            LoadClientMeetings();
            LoadPastMeetings(); 
        }

        private void LoadServices()
        {
            var services = DBServiceHelper.GetAllServices();
            Services.Clear();
            foreach (var s in services)
                Services.Add(s);
        }

        private void LoadEmployees()
        {
            var employees = DBServiceHelper.GetAllEmployees();
            Employees.Clear();
            foreach (var e in employees)
                Employees.Add(e);
        }

        private void LoadClientMeetings()
        {
            var meetings = _meetingRepository.GetMeetingsByClientId(ConnectedClientId);
            ClientMeetings.Clear();
            foreach (var m in meetings)
                ClientMeetings.Add(m);
        }

        private void LoadPastMeetings()
        {
            var pastMeetings = _meetingRepository.GetPastMeetingsByClientId(ConnectedClientId);
            PastMeetings.Clear();
            foreach (var m in pastMeetings)
                PastMeetings.Add(m);
        }

        private void OnBookMeeting()
        {
            if (SelectedService == null || SelectedEmployee == null)
            {
                Application.Current.MainPage.DisplayAlert("Erreur", "Veuillez sélectionner un service et un employé.", "OK");
                return;
            }

            if (Tools.CheckTools.Date_Check_Entries.IsDateInPast(SelectedDate, SelectedTime))
            {
                Application.Current.MainPage.DisplayAlert("Erreur", "Impossible de réserver un rendez-vous dans le passé ! Ou alors il faut une dolorean 🚘...", "OK");
                return;
            }

            var newMeeting = new Meeting
            {
                DateMeeting = SelectedDate,
                TimeMeeting = SelectedTime,
                ServiceId = SelectedService.Id,
                EmployeeId = SelectedEmployee.Id,
                ClientId = ConnectedClientId,
                Status = "Prévu"
            };

            _meetingRepository.AddMeeting(newMeeting);
            Application.Current.MainPage.DisplayAlert("Succès", "Rendez-vous réservé !", "OK");

            LoadClientMeetings();
            LoadPastMeetings();
        }


    }
}
