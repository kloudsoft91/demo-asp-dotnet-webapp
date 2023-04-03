namespace ParkingWebApplication.Models
{
    public class ParkingKiosk
    {
        protected int _ChargePerHour;
        protected int _FreeHours;
        protected int _BaseCharge;
        private int _MaxParkingHours;
        public DateTime? parkingStart;
        public DateTime? parkingEnd;
        protected int? _ParkingHours;

        public ParkingKiosk()
        {
            parkingStart = null;
            parkingEnd = null;
            _ChargePerHour = 2;
            _FreeHours = 0;
            _BaseCharge = 0;
            _MaxParkingHours = 24;
        }

        public ParkingKiosk(DateTime startTime, DateTime endTime)
        {
            parkingStart = startTime;
            parkingEnd = endTime;
            _ChargePerHour = 2;
            _FreeHours = 0;
            _BaseCharge = 0;
            _MaxParkingHours = 24;
        }

        public DateTime ParkingStart
        {
            set { parkingStart = value; }
        }

        public DateTime ParkingEnd
        {
            set { parkingStart = value; }
        }

        public int HoursParked
        {
            get
            {
                if (parkingStart.HasValue && parkingEnd.HasValue)
                {
                    double ParkingTime = (parkingEnd.Value.Ticks - parkingStart.Value.Ticks) / TimeSpan.TicksPerHour;
                    int ParkingHours = (int)Math.Ceiling(ParkingTime);
                    _ParkingHours = ParkingHours;
                    return _ParkingHours.Value;
                }
                else
                {
                    throw new Exception("ParkingTimesNotDefined");
                }
            }
        }

        public int CalculateParkingCharge()
        {
            if (!_ParkingHours.HasValue)
            {
                double ParkingTime = (parkingEnd.Value.Ticks - parkingStart.Value.Ticks) / TimeSpan.TicksPerHour;
                int ParkingHours = (int)Math.Ceiling(ParkingTime);
                _ParkingHours = ParkingHours;
            }
            if (_ParkingHours.Value <= _FreeHours && _ParkingHours.Value > 0)
            {
                return _BaseCharge;
            }
            else if (_ParkingHours.Value < _MaxParkingHours)
            {
                return (_ParkingHours.Value - _FreeHours) * _ChargePerHour + _BaseCharge;
            }
            else
            {
                throw new Exception("ParkingException");
            }
        }
    }
}
