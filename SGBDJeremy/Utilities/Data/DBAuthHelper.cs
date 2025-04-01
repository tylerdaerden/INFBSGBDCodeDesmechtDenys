using System;
using Microsoft.Data.SqlClient;
using SGBDJeremy.Models;

namespace SGBDJeremy.Utilities.Data
{
    public static class DBAuthHelper
    {
        private const string ConnectionString = "Data Source=PORTABLE_DENYS\\DATAIRAMPS;Initial Catalog=SGBDINFB;Integrated Security=True;Trust Server Certificate=True;";

        /// <summary>
        /// Récupère un client depuis l'adresse email.
        /// </summary>
        public static Client GetClientByEmail(string email)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string query = "SELECT Id, FirstName, LastName, PhoneNumber, Email, Password FROM Client WHERE Email = @Email";

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Email", email);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Client
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    PhoneNumber = reader.GetString(3),
                    Email = reader.GetString(4),
                    Password = reader.GetString(5)
                };
            }

            return null; // Aucun client trouvé
        }

        /// <summary>
        /// Récupère un employé depuis l'adresse email.
        /// </summary>
        public static Employee GetEmployeeByEmail(string email)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string query = "SELECT Id, FirstName, LastName, PhoneNumber, Email, Password, Role FROM Employee WHERE Email = @Email";

            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Email", email);

            using SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Employee
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    PhoneNumber = reader.GetString(3),
                    Email = reader.GetString(4),
                    Password = reader.GetString(5),
                    Role = reader.GetString(6)
                };
            }

            return null; // Aucun employé trouvé
        }
    }
}
