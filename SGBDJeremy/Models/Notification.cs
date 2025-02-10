using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBDJeremy.Models
{
    public class Notification
    {
        private string _idNotification;
        private string _type;
        private DateTime _sendDate;
        private string _status;

        public string IdNotification 
        { 
            get => _idNotification; 
            set => _idNotification = value; 
        }
        public string Type
        {
            get => _type;
            set => _type = value;
        }
        public DateTime SendDate
        {
            get => _sendDate;
            set => _sendDate = value;
        }
        public string Status
        {
            get => _status;
            set => _status = value;
        }




    }
}
