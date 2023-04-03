using System.Data;
using MySqlX.XDevAPI;
using MySql.Data.MySqlClient;
using ParkingWebApplication.Models;

namespace ParkingWebApplication.Data
{
    public class ParkingDBContext
    {
        private static string? _db_hostname = Environment.GetEnvironmentVariable("DBHOST");
        private static string? _db_port = Environment.GetEnvironmentVariable("DBPORT");
        private static string? _db_user = Environment.GetEnvironmentVariable("DBUSER");
        private static string? _db_pass = Environment.GetEnvironmentVariable("DBPASS");
        private static string? _db_name = Environment.GetEnvironmentVariable("DBNAME");
        private static string? _connectionString = "server=" + _db_hostname +
                                                   ";port=" + _db_port +
                                                   ";database=" + _db_name +
                                                   ";user=" + _db_user +
                                                   ";password=" + _db_pass +
                                                   ";compression=disabled" +
                                                   ";sslmode=Required" + ";";

        public ParkingDBContext()
        {
            var session = MySQLX.GetSession(_connectionString);
            string createTable = "CREATE TABLE IF NOT EXISTS Bookings ( Id  INT NOT NULL AUTO_INCREMENT, Rego LONGTEXT CHARSET utf8mb4, Type LONGTEXT CHARSET utf8mb4, ParkingStart DATETIME, ParkingEnd DATETIME, PRIMARY KEY (Id) ) ENGINE=InnoDB;";
            var result = session.SQL(createTable.ToString()).Execute();
        }

        public List<ParkingBooking> AllBookings()
        {
            var bookings = new List<ParkingBooking>();

            var session = MySQLX.GetSession(_connectionString);
            var result = session.SQL("SELECT * FROM Bookings ORDER BY Id ASC;").Execute();
            var result_rows = result.FetchAll();

            foreach (var row in result_rows)
            {
                bookings.Add(new ParkingBooking()
                {
                    Id = Convert.ToInt32(row[0]),
                    Rego = row[1].ToString(),
                    Type = row[2].ToString(),
                    ParkingStart = (DateTime)row[3],
                    ParkingEnd = (DateTime)row[4],
                });
            }
            return bookings;
        }

        public void Insert(ParkingBooking booking)
        {
            var session = MySQLX.GetSession(_connectionString);
            string cmd = "INSERT INTO Bookings (Rego, Type, ParkingStart, ParkingEnd) VALUES ('" +
                                 booking.Rego + "', '" +
                                 booking.Type + "', '" +
                                 booking.ParkingStart.ToString("yyyy-MM-dd HH:mm:ss") + "', '" +
                                 booking.ParkingEnd.ToString("yyyy-MM-dd HH:mm:ss") + "');";
            var result = session.SQL(cmd.ToString()).Execute();
        }
    }
}