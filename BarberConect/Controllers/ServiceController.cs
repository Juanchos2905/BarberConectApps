using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using BarberConect.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberConect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        //GET SERVICES
        [HttpGet, ActionName("Get")]
        [Route("GetRoles")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServicesAsync()
        {
            var services = await _serviceService.GetServicesAsync();
            if (services == null || !services.Any())
            {
                return NotFound();
            }

            return Ok(services);
        }
        //GET SERVICE BY ID
        [HttpGet, ActionName("Get")]
        [Route("GetRolesById")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServiceByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("Id es requerido!");

            var services = await _serviceService.GetServiceByIdAsync(id);
            if (services == null)
            {
                return NotFound();
            }

            return Ok(services);
        }
    }
}
