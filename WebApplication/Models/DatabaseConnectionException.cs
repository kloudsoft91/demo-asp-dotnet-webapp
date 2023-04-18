using System;
namespace ParkingWebApplication.Models
{
    public class DatabaseConnectionException : Exception
    {
        public string _connectionString { get; }

        public DatabaseConnectionException(string connectionString) : base("Database connection timed out. Check the database and try again.")
        {
            _connectionString = connectionString;
        }
    }
}
