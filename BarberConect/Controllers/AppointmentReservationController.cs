using Microsoft.AspNetCore.Mvc;

namespace BarberConect.Controllers
{
    public class AppointmentReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
