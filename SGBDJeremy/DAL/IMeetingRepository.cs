using SGBDJeremy.Models;
using System.Collections.Generic;

namespace SGBDJeremy.DAL.Interfaces
{
    /// <summary>
    /// Interface définissant les opérations CRUD ou spécifiques pour les entités de type Meeting.
    /// Permet une abstraction de la couche d’accès aux données (DAL).
    /// </summary>
    public interface IMeetingRepository
    {
        List<Meeting> GetMeetingsByClientId(int clientId);
        void AddMeeting(Meeting meeting);
    }
}
