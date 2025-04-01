using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using SGBDJeremy.Models;

namespace SGBDJeremy.Utilities.Data
{
    public static class DBServiceHelper
    {
        private const string ConnectionString = "Data Source=PORTABLE_DENYS\\DATAIRAMPS;Initial Catalog=SGBDINFB;Integrated Security=True;Trust Server Certificate=True;";

        // Obtenir tous les services
        public static List<Service> GetAllServices()
        {
            var services = new List<Service>();

            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            var query = "SELECT Id, Name, Description, Price FROM Service";
            using SqlCommand cmd = new SqlCommand(query, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                services.Add(new Service
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Price = reader.GetDecimal(3)
                });
            }

            return services;
        }

        // Obtenir tous les employés
        public static List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            var query = "SELECT Id, FirstName, LastName, PhoneNumber, Email, Role FROM Employee";
            using SqlCommand cmd = new SqlCommand(query, connection);
            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                employees.Add(new Employee
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    PhoneNumber = reader.GetString(3),
                    Email = reader.GetString(4),
                    Role = reader.GetString(5)
                });
            }

            return employees;
        }

        // Obtenir les rendez-vous d’un client donné
        // ⚠️ Obsolète - Utiliser IMeetingRepository à la place
        [Obsolete("Utiliser MeetingRepository via IMeetingRepository")]
        #region OBSOLETE
        public static List<Meeting> GetMeetingsByClientId(int clientId)
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
        #endregion

        // Ajouter un rendez-vous
        // ⚠️ Obsolète - Utiliser IMeetingRepository à la place
        #region OBSOLETE
        [Obsolete("Utiliser MeetingRepository via IMeetingRepository")]
        public static void AddMeeting(Meeting meeting)
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
        #endregion

        public static List<Meeting> GetMeetingsByEmployeeId(int employeeId)
        {
            var meetings = new List<Meeting>();

            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string query = @"
        SELECT M.MeetingID, M.DateMeeting, M.TimeMeeting, M.Status,
               M.ClientId,
               C.FirstName + ' ' + C.LastName AS ClientName,
               S.Name AS ServiceName
        FROM Meeting M
        INNER JOIN Client C ON M.ClientId = C.Id
        INNER JOIN Service S ON M.ServiceId = S.Id
        WHERE M.EmployeeId = @EmployeeId";

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                meetings.Add(new Meeting
                {
                    MeetingID = reader.GetInt32(0),
                    DateMeeting = reader.GetDateTime(1),
                    TimeMeeting = reader.GetTimeSpan(2),
                    Status = reader.GetString(3),
                    ClientId = reader.GetInt32(4),
                    ClientName = reader.GetString(5),
                    ServiceName = reader.GetString(6)
                });
            }

            return meetings;
        }

        public static bool AddClient(Client c)
        {
            try
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                string query = @"
            INSERT INTO Client (FirstName, LastName, PhoneNumber, Email, Password)
            VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Password);";

                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", c.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@Password", c.Password);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'ajout du client : " + ex.Message);
                return false;
            }
        }




    }
}
