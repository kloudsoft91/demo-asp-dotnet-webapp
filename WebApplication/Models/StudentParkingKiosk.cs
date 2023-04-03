namespace ParkingWebApplication.Models
{
    public class StudentParkingKiosk : ParkingKiosk
    {
        public StudentParkingKiosk() : base()
        {
            _ChargePerHour = 1;
        }

        public StudentParkingKiosk(DateTime parkingStart, DateTime parkingEnd) : base(parkingStart, parkingEnd)
        {
            _ChargePerHour = 1;
        }
    }
}
