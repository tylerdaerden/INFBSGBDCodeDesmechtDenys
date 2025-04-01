﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBDJeremy.Models
{
    //Classe présente dans le diagramme reçu, pas utilisée car usage d'alertes , mais si projet + poussée ça aurait été implémenté
    public class Notification
    {
        private string _notificationID;
        private string _type;
        private DateTime _sendDate;
        private string _status;

        public string NotificationID
        { 
            get => _notificationID; 
            set => _notificationID = value; 
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
