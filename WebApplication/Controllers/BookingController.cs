using Microsoft.AspNetCore.Mvc;
using ParkingWebApplication.Data;
using ParkingWebApplication.Models;

namespace ParkingWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        // GET api/booking
        [HttpGet]
        public IActionResult GetAll()
        {
            ParkingDBContext context = HttpContext.RequestServices.GetService(typeof(ParkingWebApplication.Data.ParkingDBContext)) as ParkingDBContext;
            return new OkObjectResult(context.AllBookings());
        }

        // POST api/booking
        [HttpPost]
        public IActionResult Post([FromBody] ParkingBooking body)
        {
            new ParkingDBContext().Insert(body);
            return new OkObjectResult("");
        }
    }
}