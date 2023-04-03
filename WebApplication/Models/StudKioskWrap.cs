namespace ParkingWebApplication.Models
{
    public class StudKioskWrap : IKiosk
    {
        private StudentParkingKiosk _studParkingKiosk;

        public StudKioskWrap(DateTime startTime, DateTime endTime)
        {
            _studParkingKiosk = new StudentParkingKiosk(startTime, endTime);
        }

        public int HoursParked
        {
            get { return _studParkingKiosk.HoursParked; }
        }

        public int FindParkingAmount()
        {
            return _studParkingKiosk.CalculateParkingCharge();
        }
    }
}
