namespace SGBDJeremy.Models
{
    public class Meeting
    {
        private int _meetingID;
        private DateTime _dateMeeting;
        private TimeSpan _timeMeeting;
        private string _status;
        private int _clientId;
        private int _employeeId;
        private int _serviceId;
        private string _clientName;
        private string _serviceName;
        private string _employeeName;

        public int MeetingID
        {
            get => _meetingID;
            set => _meetingID = value;
        }

        public DateTime DateMeeting
        {
            get => _dateMeeting;
            set => _dateMeeting = value;
        }

        public TimeSpan TimeMeeting
        {
            get => _timeMeeting;
            set => _timeMeeting = value;
        }

        public string Status
        {
            get => _status;
            set => _status = value;
        }

        public int ClientId
        {
            get => _clientId;
            set => _clientId = value;
        }

        public int EmployeeId
        {
            get => _employeeId;
            set => _employeeId = value;
        }

        public int ServiceId
        {
            get => _serviceId;
            set => _serviceId = value;
        }

        public string ClientName
        {
            get => _clientName;
            set => _clientName = value;
        }

        public string ServiceName
        {
            get => _serviceName;
            set => _serviceName = value;
        }

        public string EmployeeName
        {
            get => _employeeName;
            set => _employeeName = value;
        }

        // Méthodes métiers (qui devraient figurer dans IMeeting si elles étaient développées si le programme était + poussé et non ici , je les ai mise pour coller au Diagramme reçu de Jeremy )
        public void ConfirmMeeting() => throw new NotImplementedException();
        public void CancelMeeting() => throw new NotImplementedException();
        public void UpdateMeeting(DateTime newDate) => throw new NotImplementedException();
    }
}
