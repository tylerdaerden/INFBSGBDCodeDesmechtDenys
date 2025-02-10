using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBDJeremy.Models
{
    public class Meeting
    {
        private int _idMeeting ;
        private DateTime _dateMeeting;
        private TimeOnly _timeMeeting;
        private string _status;


        public int IdMeeting 
        { 
            get => _idMeeting;
            set => _idMeeting = value;
        }
        public DateTime DateMeeting
        {
            get => _dateMeeting;
            set => _dateMeeting = value;
        }
        public TimeOnly TimeMeeting
        {
            get => _timeMeeting;
            set => _timeMeeting = value;
        }
        public string Status
        {
            get => _status; 
            set => _status = value;
        }

    }
}
