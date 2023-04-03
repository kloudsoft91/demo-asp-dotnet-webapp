using ParkingWebApplication.Data;

namespace ParkingWebApplication.Models
{
	public class ParkingBooking
	{
        private ParkingDBContext context;
        public int Id { get; set; }
        public string Rego { get; set; }
        public string Type { get; set; }
        public DateTime ParkingStart { get; set; }
        public DateTime ParkingEnd { get; set; }
    }
}

