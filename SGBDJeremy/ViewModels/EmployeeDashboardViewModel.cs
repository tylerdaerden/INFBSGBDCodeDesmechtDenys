using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SGBDJeremy.Models;
using SGBDJeremy.Utilities.Data;

namespace SGBDJeremy.ViewModels
{
    public class EmployeeDashboardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public ObservableCollection<Meeting> EmployeeMeetings { get; set; } = new();

        public int ConnectedEmployeeId { get; set; }

        public EmployeeDashboardViewModel(int employeeId)
        {
            ConnectedEmployeeId = employeeId;
            LoadEmployeeMeetings();
        }

        private void LoadEmployeeMeetings()
        {
            var meetings = DBServiceHelper.GetMeetingsByEmployeeId(ConnectedEmployeeId);
            EmployeeMeetings.Clear();
            foreach (var meeting in meetings)
                EmployeeMeetings.Add(meeting);
        }
    }
}
