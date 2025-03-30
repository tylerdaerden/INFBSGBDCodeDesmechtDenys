using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient;


namespace SGBDJeremy.Utilities.Data
{
    public class DatabaseInitializer
    {
        const string SSMSconnectionstring = "Data Source=PORTABLE_DENYS\\DATAIRAMPS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;";
        const string WorkDB = "SGBDINFB";
        const string WorkDBconnectionstring = "Data Source=PORTABLE_DENYS\\DATAIRAMPS;Initial Catalog=SGBDINFB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public static void InitializeDatabase(string serverConnectionString, string databaseName)
        {
            CreateDatabaseIfNotExists(serverConnectionString, databaseName);

            string databaseConnectionString = $"{serverConnectionString};Database={databaseName}";
            CreateTables(databaseConnectionString);
        }

        private static void CreateDatabaseIfNotExists(string connectionString, string databaseName)
        {
            connectionString = SSMSconnectionstring;
            databaseName = WorkDB;

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string checkDbQuery = $@"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{databaseName}')
                BEGIN
                    CREATE DATABASE [{databaseName}];
                END";

            using SqlCommand cmd = new SqlCommand(checkDbQuery, connection);
            cmd.ExecuteNonQuery();
        }

        private static void CreateTables(string connectionString)
        {
            connectionString = WorkDBconnectionstring;

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            // Création de la table Client
            string createClientTableQuery = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Client' AND xtype='U')
                BEGIN
                    CREATE TABLE Client (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        FirstName NVARCHAR(50) NOT NULL,
                        LastName NVARCHAR(50) NOT NULL,
                        PhoneNumber NVARCHAR(20) NOT NULL,
                        Email NVARCHAR(100) NOT NULL,
                        Password NVARCHAR(100) NOT NULL,
                        CHECK (LEN(PhoneNumber) >= 8),
                        CHECK (Email LIKE '%@%.%')
                    );
                END";

            using SqlCommand cmd = new SqlCommand(createClientTableQuery, connection);
            cmd.ExecuteNonQuery();







        }
    }
}
