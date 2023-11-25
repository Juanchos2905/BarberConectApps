using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using BarberConect.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberConect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        //GET login
        [HttpGet, ActionName("Get")]
        [Route("GetLogin")]
        public async Task<ActionResult<User>> GetLoginAsync(string email, string password)
        {
            var login = await _loginService.GetLoginAsync(email, password);
            if (login == null)
            {
                return NotFound("Credenciales incorrectas, verifique la informacion");
            }

            return Ok("Bienvenido: " + login.Name);
        }
    }
}
