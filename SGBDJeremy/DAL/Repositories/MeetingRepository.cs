using SGBDJeremy.DAL.Interfaces;
using SGBDJeremy.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace SGBDJeremy.DAL.Repositories
{
    /// <summary>
    /// Implémentation concrète de l’interface IMeetingRepository.
    /// Contient la logique d’accès aux données pour l’entité Meeting.
    /// </summary>
    public class MeetingRepository : IMeetingRepository
    {
        private const string ConnectionString = "Data Source=PORTABLE_DENYS\\DATAIRAMPS;Initial Catalog=SGBDINFB;Integrated Security=True;Trust Server Certificate=True;";

        public List<Meeting> GetMeetingsByClientId(int clientId)
        {
            var meetings = new List<Meeting>();

            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string query = @"
                SELECT M.MeetingID, M.DateMeeting, M.TimeMeeting, M.Status,
                       M.EmployeeId, M.ServiceId,
                       E.FirstName + ' ' + E.LastName AS EmployeeName,
                       S.Name AS ServiceName
                FROM Meeting M
                INNER JOIN Employee E ON M.EmployeeId = E.Id
                INNER JOIN Service S ON M.ServiceId = S.Id
                WHERE M.ClientId = @ClientId";

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ClientId", clientId);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                meetings.Add(new Meeting
                {
                    MeetingID = reader.GetInt32(0),
                    DateMeeting = reader.GetDateTime(1),
                    TimeMeeting = reader.GetTimeSpan(2),
                    Status = reader.GetString(3),
                    EmployeeId = reader.GetInt32(4),
                    ServiceId = reader.GetInt32(5),
                    EmployeeName = reader.GetString(6),
                    ServiceName = reader.GetString(7)
                });
            }

            return meetings;
        }

        public void AddMeeting(Meeting meeting)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string query = @"
                INSERT INTO Meeting (DateMeeting, TimeMeeting, Status, ClientId, EmployeeId, ServiceId)
                VALUES (@Date, @Time, @Status, @ClientId, @EmployeeId, @ServiceId)";

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Date", meeting.DateMeeting);
            cmd.Parameters.AddWithValue("@Time", meeting.TimeMeeting);
            cmd.Parameters.AddWithValue("@Status", meeting.Status);
            cmd.Parameters.AddWithValue("@ClientId", meeting.ClientId);
            cmd.Parameters.AddWithValue("@EmployeeId", meeting.EmployeeId);
            cmd.Parameters.AddWithValue("@ServiceId", meeting.ServiceId);

            cmd.ExecuteNonQuery();
        }
    }
}
