using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBDJeremy.Models
{
    public class Meeting
    {
        private int _meetingID ;
        private DateTime _dateMeeting;
        private TimeOnly _timeMeeting;
        private string _status;


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



        //methods

        public void ConfirmMeeting()
        {
            throw new NotImplementedException();
        }

        public void CancelMeeting() 
        {
            throw new NotImplementedException();
        }

        public void PostponeMeeting()
        { 
            throw new NotImplementedException(); 
        }


    }
}
