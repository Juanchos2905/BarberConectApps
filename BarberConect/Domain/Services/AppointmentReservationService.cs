using BarberConect.DAL;
using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberConect.Domain.Services
{
    public class AppointmentReservationService : IAppointmentReservationService
    {
        private readonly DataBaseContext _context;

        public AppointmentReservationService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<AppointmentReservation> CreateAppointmentReservationAsync(AppointmentReservation appointmentReservation, Guid userId)
        {
            try
            {
                appointmentReservation.Id = Guid.NewGuid();
                appointmentReservation.CreateDate = DateTime.Now;
                appointmentReservation.UserId = userId;
                appointmentReservation.AppointmentStatus = "Confirmado";
                //appointmentReservation. = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                appointmentReservation.ModifiedDate = null;


                _context.AppointmentReservations.Add(appointmentReservation);
                await _context.SaveChangesAsync();

                return appointmentReservation;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }


        public async Task<IEnumerable<AppointmentReservation>> GetAppointmentReservationByDayAsync(DateTime date)
        {
            string dt = date.ToString("yyyy-MM-dd");
            string day = dt + "T00:00:00";
            return await _context.AppointmentReservations
                .Where(a => a.Date == DateTime.Parse(day))
                .Include(s => s.Services)
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentReservation>> GetAppointmentReservationsAsync()
        {
            return await _context.AppointmentReservations
                .Include(s => s.Services)
                .ToListAsync();
        }

        public async Task<AppointmentReservation> UpdateAppointmentReservationAsync(Guid id)
        {
            try
            {
                var CancelAppointment = await _context.AppointmentReservations
                    .FirstOrDefaultAsync(i => i.Id == id);

                if (CancelAppointment == null)
                {
                    throw new InvalidOperationException("AppointmentReservation not found");
                }


                if (CancelAppointment.AppointmentStatus == "Confirmado")
                {
                    CancelAppointment.AppointmentStatus = "Cancelado";
                    CancelAppointment.ModifiedDate = DateTime.Now;
                    _context.AppointmentReservations.Update(CancelAppointment);
                    await _context.SaveChangesAsync();
                    return CancelAppointment;

                }
                else
                {
                    throw new Exception("AppointmentReservation is already canceled.");
                }

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<AppointmentReservation> ValidateAppointmentReservationAsync(DateTime date, string time)
        {
            string dt = date.ToString("yyyy-MM-dd");
            string day = dt + "T00:00:00";
            return await _context.AppointmentReservations
                .FirstOrDefaultAsync(a => a.Date == DateTime.Parse(day) && a.Time == time);
        }
    }
}
