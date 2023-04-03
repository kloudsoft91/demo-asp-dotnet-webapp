namespace ParkingWebApplication.Models
{
    public interface IKiosk
    {
        int HoursParked
        {
            get;
        }

        int FindParkingAmount();
    }
}
