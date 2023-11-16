using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace BarberConect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarberController : Controller
    {
        private readonly IBarberService _barberService;
        public BarberController(IBarberService barberService)
        {
            _barberService = barberService;
        }

        //GET BARBERS
        [HttpGet, ActionName("Get")]
        [Route("GetBarbers")]
        public async Task<ActionResult<IEnumerable<Barber>>> GetBarbersAsync()
        {
            var barbers = await _barberService.GetBarbersAsync();
            if (barbers == null || !barbers.Any())
            {
                return NotFound();
            }

            return Ok(barbers);
        }
        //CREATE BARBER 
        [HttpPost, ActionName("Create")]
        [Route("CreateBarber")]
        public async Task<ActionResult> CreateBarberAsync(Barber barber)
        {
            try
            {
                var createBarber = await _barberService.CreateBarberAsync(barber);
                if (createBarber == null)
                {
                    return NotFound();
                }
                return Ok(createBarber);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El barbero {0} ya existe ", barber.Id));
                }
                return Conflict(ex.Message);
            }
        }

    }
}
