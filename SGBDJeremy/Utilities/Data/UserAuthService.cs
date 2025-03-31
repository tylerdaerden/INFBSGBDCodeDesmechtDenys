using Microsoft.Data.SqlClient;

namespace SGBDJeremy.Utilities.Data
{
    public static class UserAuthService
    {
        // Connexion à la DB de travail
        private const string connectionString = "Data Source=PORTABLE_DENYS\\DATAIRAMPS;Initial Catalog=SGBDINFB;Integrated Security=True;Trust Server Certificate=True;";

        /// <summary>
        /// Vérifie si un client avec cet email + mot de passe existe
        /// </summary>
        public static bool AuthenticateClient(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT COUNT(1)
                    FROM Client
                    WHERE Email = @Email AND Password = @Password;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static bool AuthenticateEmployee(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
            SELECT COUNT(1)
            FROM Employee
            WHERE Email = @Email AND Password = @Password;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }



    }
}
