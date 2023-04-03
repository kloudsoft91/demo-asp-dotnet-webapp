using Microsoft.AspNetCore.Mvc;
using ParkingWebApplication.Data;
using ParkingWebApplication.Models;
using System.Net.Http;

namespace ParkingWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }

        private ParkingBooking ConvertToBooking(ParkingCostModel model)
        {
            ParkingBooking data = new ParkingBooking();
            data.Rego = model.Rego;
            data.Type = model.Type;
            data.ParkingStart = model.ParkingStart;
            data.ParkingEnd = model.ParkingEnd;
            return data;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ParkingCostModel model)
        {
            if (ModelState.IsValid)
            {
                IKiosk kiosk;
                DateTime startTime;
                DateTime endTime;

                startTime = model.ParkingStart;
                endTime = model.ParkingEnd;

                if (model.Type == "Student")
                {
                    kiosk = new StudKioskWrap(startTime, endTime);
                }
                else if (model.Type == "Staff")
                {
                    kiosk = new StaffKioskWrap(startTime, endTime);
                }
                else
                {
                    kiosk = new GenKioskWrap(startTime, endTime);
                }
                new ParkingDBContext().Insert(ConvertToBooking(model));
                ViewBag.result = kiosk.FindParkingAmount().ToString();

            }
            return View();
        }
    }
}
