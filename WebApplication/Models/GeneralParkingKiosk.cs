namespace ParkingWebApplication.Models
{
    public class GeneralParkingKiosk : ParkingKiosk
    {
        public GeneralParkingKiosk() : base()
        {

        }

        public GeneralParkingKiosk(DateTime parkingStart, DateTime parkingEnd) : base(parkingStart, parkingEnd)
        {

        }
    }
}
