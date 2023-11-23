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
        public async Task<ActionResult<IEnumerable<User>>> GetBarbersAsync()
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
        public async Task<ActionResult> CreateBarberAsync(User barber)
        {
            try
            {
                var createBarber = await _barberService.CreateBarberAsync(barber);
                if (createBarber == null)
                {
                    return NotFound("Verifique la informacion suministrada");
                }
                if (createBarber.Age > 0 && createBarber.Age <= 100)
                {
                    return Ok(createBarber);
                }
                return Conflict(String.Format("Verifique que la informacion suministrada sea correcta"));
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
        //DELETE BARBER
        [HttpDelete, ActionName("Delete")]
        [Route("DeleteBarber")]
        public async Task<ActionResult<User>> DeleteBarberAsync(Guid id)
        {
            if (id == null) return BadRequest("El id del barbero es requerido!");

            var deletedBarber = await _barberService.DeleteBarberAsync(id);
            if (deletedBarber == null)
            {
                return NotFound("Barbero no encontrado.");
            }

            return Ok(deletedBarber);
        }
        //UPDATE BARBER
        [HttpPut, ActionName("Update")]
        [Route("UpdaterBarber")]
        public async Task<ActionResult<User>> EditBarberAsync(User barber)
        {
            try
            {
                var editedBarber = await _barberService.EditBarberAsync(barber);
                if (editedBarber == null)
                {
                    return NotFound("Verifique la informacion suministrada");
                }
                if (editedBarber.Age > 0 && editedBarber.Age <= 100)
                {
                    return Ok(editedBarber);
                }
                return Conflict(String.Format("Verifique que la informacion suministrada sea correcta"));
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("canceled"))
                    return Conflict(String.Format("La cita ya ha sido cancelada."));

                return Conflict(ex.Message);
            }

        }
    }
}
