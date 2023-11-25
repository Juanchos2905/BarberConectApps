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
        //CREATE SERVICES
        [HttpPost, ActionName("Create")]
        [Route("CreateService")]
        public async Task<ActionResult> CreateServiceAsync(Service service, Guid appointmentReservationId)
        {
            try
            {
                var createService = await _serviceService.CreateServiceAsync(service, appointmentReservationId);
                if (createService == null)
                {
                    return NotFound("Verifique la informacion suministrada");
                }
                return Ok(createService);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El Servicio {0} ya existe ", service.Id));
                }
                return Conflict(ex.Message);
            }
        }
        //GET SERVICES
        [HttpGet, ActionName("Get")]
        [Route("GetServices")]
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
        [Route("GetServiceById")]
        public async Task<ActionResult<Service>> GetServiceByIdAsync(Guid id)
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
