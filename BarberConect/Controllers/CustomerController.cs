using Microsoft.AspNetCore.Mvc;

namespace BarberConect.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
