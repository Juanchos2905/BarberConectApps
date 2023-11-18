using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarberConect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentReservationController : Controller
    {
        private readonly IAppointmentReservationService _appointmentReservationService;


        public AppointmentReservationController(IAppointmentReservationService appointmentReservationService)
        {
            _appointmentReservationService = appointmentReservationService;
        }

        [HttpPost, ActionName("Create")]
        [Route("CreateAppointmentReservation")]
        public async Task<ActionResult> CreateAppointmentReservationAsync(AppointmentReservation appointmentReservation, Guid userId)
        {
            try
            {
                var createdReservation = await _appointmentReservationService.CreateAppointmentReservationAsync(appointmentReservation, userId);

                if (createdReservation == null) return NotFound();

                return Ok(createdReservation);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("La cita ya existe."));
                }

                return Conflict(ex.Message);
            }
        }
    }
}
