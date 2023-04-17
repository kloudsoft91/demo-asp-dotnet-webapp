//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using ParkingWebApplication.Data;
using ParkingWebApplication.Models;

namespace ParkingWebApplication.Controllers
{
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private ParkingCostModel ConvertToParkingCost(ParkingBooking model)
        {
            ParkingCostModel data = new ParkingCostModel();
            data.Rego = model.Rego;
            data.Type = model.Type;
            data.ParkingStart = model.ParkingStart;
            data.ParkingEnd = model.ParkingEnd;
            return data;
        }

        // GET api/booking
        [HttpGet]
        public IActionResult GetAll()
        {
            ParkingDBContext context = HttpContext.RequestServices.GetService(typeof(ParkingWebApplication.Data.ParkingDBContext)) as ParkingDBContext;
            return new OkObjectResult(context.AllBookings());
        }

        // GET api/booking/rego/id
        [HttpGet]
        [Route("rego/{id}")]
        public IActionResult GetByRego(string id)
        {
            try
            {
                ParkingDBContext context = HttpContext.RequestServices.GetService(typeof(ParkingWebApplication.Data.ParkingDBContext)) as ParkingDBContext;
                return new OkObjectResult(context.BookingByRego(id));
            }
            catch (EmptyQueryResultExceptionException)
            {
                return new OkObjectResult($"No results found for Rego {id}");
            }
            catch (Exception exc)
            {
                return new BadRequestObjectResult(exc.Message);
            }
        }

        // GET api/booking/type/id
        [HttpGet]
        [Route("type/{id}")]
        public IActionResult GetByType(string id)
        {
            try
            {
                ParkingDBContext context = HttpContext.RequestServices.GetService(typeof(ParkingWebApplication.Data.ParkingDBContext)) as ParkingDBContext;
                return new OkObjectResult(context.BookingByType(id));
            }
            catch (EmptyQueryResultExceptionException)
            {
                return new OkObjectResult($"No results found for Type {id}");
            }
            catch (Exception exc)
            {
                return new BadRequestObjectResult(exc.Message);
            }
        }

        // POST api/booking
        [HttpPost]
        public IActionResult Post([FromBody] ParkingBooking body)
        {
            IKiosk kiosk;
            DateTime startTime;
            DateTime endTime;

            ParkingCostModel model = ConvertToParkingCost(body);

            if (ModelState.IsValid)
            {
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
                try
                {
                    string parkingAmount = kiosk.FindParkingAmount().ToString();
                    new ParkingDBContext().Insert(body);
                    return new OkObjectResult(parkingAmount);
                }
                catch
                {
                    return new BadRequestObjectResult("Unable to book for over 24 hrs");
                }
            }
            else
            {
                return new BadRequestObjectResult("Incorrect object passed to API");
            }
        }
    }
}
