namespace ParkingWebApplication.Models
{
    public class StaffKioskWrap : IKiosk
    {
        private StaffParkingKiosk _staffParkingKiosk;

        public StaffKioskWrap(DateTime startTime, DateTime endTime)
        {
            _staffParkingKiosk = new StaffParkingKiosk(startTime, endTime);
        }

        public int HoursParked
        {
            get { return _staffParkingKiosk.HoursParked; }
        }

        public int FindParkingAmount()
        {
            return _staffParkingKiosk.CalculateParkingCharge();
        }
    }
}
