using System;
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

        /// <summary>
        /// Creation of all table in an all in one ! (poker style ♠️♦️ )
        /// </summary>
        /// <param name="connectionString"></param>
        private static void CreateTables(string connectionString)
        {
            connectionString = WorkDBconnectionstring;

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string[] tableQueries = new string[]
            {
                // Table Client
                @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Client' AND xtype='U')
                BEGIN
                    CREATE TABLE Client (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        FirstName NVARCHAR(50) NOT NULL,
                        LastName NVARCHAR(50) NOT NULL,
                        PhoneNumber NVARCHAR(20) NOT NULL,
                        Email NVARCHAR(100) NOT NULL UNIQUE,
                        Password NVARCHAR(100) NOT NULL,
                        CONSTRAINT CHK_Client_PhoneNumber_Length CHECK (LEN(PhoneNumber) >= 8),
                        CONSTRAINT CHK_Client_Email_Format CHECK (Email LIKE '%@%.%')
                    );
                END",

                // Table Employee
                @"
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
                        CONSTRAINT CHK_Employee_PhoneNumber_Length CHECK (LEN(PhoneNumber) >= 8),
                        CONSTRAINT CHK_Employee_Email_Format CHECK (Email LIKE '%@%.%')
                    );
                END",

                // Table Service
                @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Service' AND xtype='U')
                BEGIN
                    CREATE TABLE Service (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        Name NVARCHAR(100) NOT NULL,
                        Description NVARCHAR(255),
                        Price DECIMAL(10,2) NOT NULL,
                        CONSTRAINT CHK_Service_Price_Positive CHECK (Price >= 0)
                    );
                END",

                // Table Meeting
                @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Meeting' AND xtype='U')
                BEGIN
                    CREATE TABLE Meeting (
                        MeetingID INT PRIMARY KEY IDENTITY(1,1),
                        DateMeeting DATE NOT NULL,
                        TimeMeeting TIME NOT NULL,
                        Status NVARCHAR(50),
                        ClientId INT NOT NULL,
                        EmployeeId INT NOT NULL,
                        ServiceId INT NOT NULL,
                        CONSTRAINT FK_Meeting_Client FOREIGN KEY (ClientId) REFERENCES Client(Id),
                        CONSTRAINT FK_Meeting_Employee FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
                        CONSTRAINT FK_Meeting_Service FOREIGN KEY (ServiceId) REFERENCES Service(Id)
                    );
                END",

                // Table Payment
                @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Payment' AND xtype='U')
                BEGIN
                    CREATE TABLE Payment (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        MeetingId INT NOT NULL,
                        Amount DECIMAL(10,2) NOT NULL,
                        PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),
                        Method NVARCHAR(50) NOT NULL,
                        CONSTRAINT CHK_Payment_Amount_Positive CHECK (Amount >= 0),
                        CONSTRAINT FK_Payment_Meeting FOREIGN KEY (MeetingId) REFERENCES Meeting(MeetingID)
                    );
                END",

                // Table Notification
                @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Notification' AND xtype='U')
                BEGIN
                    CREATE TABLE Notification (
                        Id INT PRIMARY KEY IDENTITY(1,1),
                        ClientId INT NOT NULL,
                        Message NVARCHAR(255) NOT NULL,
                        DateSent DATETIME NOT NULL DEFAULT GETDATE(),
                        CONSTRAINT FK_Notification_Client FOREIGN KEY (ClientId) REFERENCES Client(Id)
                    );
                END"
            };

            foreach (string query in tableQueries)
            {
                using SqlCommand cmd = new SqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
