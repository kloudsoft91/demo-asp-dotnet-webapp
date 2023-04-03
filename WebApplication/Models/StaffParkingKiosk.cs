namespace ParkingWebApplication.Models
{
    public class StaffParkingKiosk : ParkingKiosk
    {
        public StaffParkingKiosk() : base()
        {
            _FreeHours = 10;
            _BaseCharge = 2;
        }

        public StaffParkingKiosk(DateTime parkingStart, DateTime parkingEnd) : base(parkingStart, parkingEnd)
        {
            _FreeHours = 10;
            _BaseCharge = 2;
        }
    }
}
