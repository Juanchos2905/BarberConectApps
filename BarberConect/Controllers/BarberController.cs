using Microsoft.AspNetCore.Mvc;

namespace BarberConect.Controllers
{
    public class BarberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
