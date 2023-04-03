namespace ParkingWebApplication.Models
{
    public class GenKioskWrap : IKiosk
    {
        private GeneralParkingKiosk _genParkingKiosk;

        public GenKioskWrap(DateTime startTime, DateTime endTime)
        {
            _genParkingKiosk = new GeneralParkingKiosk(startTime, endTime);
        }

        public int HoursParked
        {
            get { return _genParkingKiosk.HoursParked; }
        }

        public int FindParkingAmount()
        {
            return _genParkingKiosk.CalculateParkingCharge();
        }
    }
}
