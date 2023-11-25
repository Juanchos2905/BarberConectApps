using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using BarberConect.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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
        //CREATE APPOINTMENTRESERVATION
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
            catch (Exception ex)// HTTP 409 CONFLICT
            {
                if (ex.Message.Contains("Verifique"))
                {
                    return Conflict(String.Format("Por favor verifique que la informacion suministrada sea correcta. \n " +
                    "Señor usuario, recuerde que nuestro horario de atención es desde las 9AM a 9PM (HORARIO 24Hrs)."));
                }
                else if(ex.Message.Contains("Input"))
                {
                    return Conflict(String.Format("Usted ingresó la letra: '" + appointmentReservation.Time + "'.\n" +
                        "Por favor ingresar un número.\n" +
                        "Señor usuario, recuerde que nuestro horario de atención es desde las 9AM a 9PM (HORARIO 24Hrs)."));
                }
                return Conflict(ex.Message);
            }
        }
        //GET APPOINTMENTRESERVATION
        [HttpGet, ActionName("Get")]
        [Route("GetAppointmentReservations")]
        public async Task<ActionResult<IEnumerable<AppointmentReservation>>> GetAppointmentReservationsAsync()
        {
            var AppointmentReservations = await _appointmentReservationService.GetAppointmentReservationsAsync();
            if (AppointmentReservations == null || !AppointmentReservations.Any())
            {
                return NotFound();
            }

            return Ok(AppointmentReservations);
        }
        //CANCEL APPOINTMENT
        [HttpPut, ActionName("Cancel")]
        [Route("CancelAppointment")]
        public async Task<ActionResult<AppointmentReservation>> UpdateAppointmentReservationAsync(Guid id)
        {
            try
            {
                var cancelAppointment = await _appointmentReservationService.UpdateAppointmentReservationAsync(id);

                return Ok(cancelAppointment);
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("canceled"))
                    return Conflict(String.Format("La cita ya ha sido cancelada."));

                return Conflict(ex.Message);
            }
        }
        //GET APPOINTMENTRESERVATIONBYDAY
        [HttpGet, ActionName("Get")]
        [Route("GetAppointmentReservationByDayAsync")]
        public async Task<ActionResult<IEnumerable<AppointmentReservation>>> GetAppointmentReservationByDayAsync(string date)
        {
            var AppointmentReservations = await _appointmentReservationService.GetAppointmentReservationByDayAsync(date);
            if (AppointmentReservations == null || !AppointmentReservations.Any())
            {
                return NotFound();
            }

            return Ok(AppointmentReservations);
        }
        //GET VALIDATEAPPOINTMENTRESERVATION
        [HttpGet, ActionName("Get")]
        [Route("ValidateAppointmentReservationAsync")]
        public async Task<ActionResult<IEnumerable<AppointmentReservation>>> ValidateAppointmentReservationAsync(string date, string time)
        {
            var AppointmentReservations = await _appointmentReservationService.ValidateAppointmentReservationAsync(date, time);
            if (AppointmentReservations == null)
            {
                return Ok("Puedes reservar cita en este horario!");
            }

            if (AppointmentReservations != null)
            {
                return Ok("Lo sentimos, ya hay reserva este día en este horario.");
            }

            return Ok();

                
        }


    }
}
