using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using SGBDJeremy.Models;
using SGBDJeremy.Utilities.Data;

namespace SGBDJeremy.ViewModels
{
    public class ClientHomeViewModel : INotifyPropertyChanged
    {
        // Événement pour la mise à jour de l’UI
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        // ID du client connecté (à passer depuis la LoginPage)
        public int ConnectedClientId { get; set; }

        // Liste des meetings
        public ObservableCollection<Meeting> ClientMeetings { get; set; } = new();
        public ObservableCollection<Meeting> PastMeetings { get; set; } = new();

        // Formulaire de réservation
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

        // Commande de réservation
        public ICommand BookMeetingCommand { get; }

        public ClientHomeViewModel(int clientId)
        {
            ConnectedClientId = clientId;

            // Commande liée au bouton "Réserver"
            BookMeetingCommand = new Command(OnBookMeeting);

            // Charger les données
            LoadServices();
            LoadEmployees();
            LoadClientMeetings();
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
            var meetings = DBServiceHelper.GetMeetingsByClientId(ConnectedClientId);
            ClientMeetings.Clear();
            PastMeetings.Clear();

            foreach (var m in meetings)
            {
                if (m.DateMeeting >= DateTime.Today)
                    ClientMeetings.Add(m);
                else
                    PastMeetings.Add(m);
            }
        }

        private void OnBookMeeting()
        {
            if (SelectedService == null || SelectedEmployee == null)
            {
                Application.Current.MainPage.DisplayAlert("Erreur", "Veuillez sélectionner un service et un employé.", "OK");
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

            DBServiceHelper.AddMeeting(newMeeting);
            Application.Current.MainPage.DisplayAlert("Succès", "Rendez-vous réservé !", "OK");

            LoadClientMeetings(); // Refresh la liste
        }
    }
}
