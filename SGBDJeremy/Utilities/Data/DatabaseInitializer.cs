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
            using (SqlCommand cmd = new SqlCommand(createClientTableQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }

            // Table Employee
            string createEmployeeTableQuery = @"
    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employee' AND xtype='U')
    BEGIN
        CREATE TABLE Employee (
            Id INT PRIMARY KEY IDENTITY(1,1),
            FirstName NVARCHAR(50) NOT NULL,
            LastName NVARCHAR(50) NOT NULL,
            PhoneNumber NVARCHAR(20) NOT NULL,
            Email NVARCHAR(100) NOT NULL UNIQUE,
            Password NVARCHAR(100) NOT NULL,
            Role NVARCHAR(50) NOT NULL,
            CHECK (LEN(PhoneNumber) >= 8),
            CHECK (Email LIKE '%@%.%')
        );
    END";
            using (SqlCommand cmd = new SqlCommand(createEmployeeTableQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }

            // Table Service
            string createServiceTableQuery = @"
        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Service' AND xtype='U')
        BEGIN
            CREATE TABLE Service (
                Id INT PRIMARY KEY IDENTITY(1,1),
                Name NVARCHAR(100) NOT NULL,
                Description NVARCHAR(255),
                Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0)
            );
        END";
            using (SqlCommand cmd = new SqlCommand(createServiceTableQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }

            // Table Meeting
            string createMeetingTableQuery = @"
        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Meeting' AND xtype='U')
        BEGIN
            CREATE TABLE Meeting (
                Id INT PRIMARY KEY IDENTITY(1,1),
                ClientId INT NOT NULL,
                EmployeeId INT NOT NULL,
                Date DATETIME NOT NULL,
                ServiceId INT NOT NULL,
                FOREIGN KEY (ClientId) REFERENCES Client(Id),
                FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
                FOREIGN KEY (ServiceId) REFERENCES Service(Id)
            );
        END";
            using (SqlCommand cmd = new SqlCommand(createMeetingTableQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }

            // Table Payment
            string createPaymentTableQuery = @"
        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Payment' AND xtype='U')
        BEGIN
            CREATE TABLE Payment (
                Id INT PRIMARY KEY IDENTITY(1,1),
                MeetingId INT NOT NULL,
                Amount DECIMAL(10,2) NOT NULL CHECK (Amount >= 0),
                PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),
                Method NVARCHAR(50) NOT NULL,
                FOREIGN KEY (MeetingId) REFERENCES Meeting(Id)
            );
        END";
            using (SqlCommand cmd = new SqlCommand(createPaymentTableQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }

            // Table Notification
            string createNotificationTableQuery = @"
        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Notification' AND xtype='U')
        BEGIN
            CREATE TABLE Notification (
                Id INT PRIMARY KEY IDENTITY(1,1),
                ClientId INT NOT NULL,
                Message NVARCHAR(255) NOT NULL,
                DateSent DATETIME NOT NULL DEFAULT GETDATE(),
                FOREIGN KEY (ClientId) REFERENCES Client(Id)
            );
        END";
            using (SqlCommand cmd = new SqlCommand(createNotificationTableQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

    }
}
