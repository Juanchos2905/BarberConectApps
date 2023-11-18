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

        public Task<AppointmentReservation> DeleteAppointmentReservationAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentReservation> UpdateAppointmentReservationAsync(AppointmentReservation appointmentReservation)
        {
            throw new NotImplementedException();
        }

        public Task<AppointmentReservation> ValidateAppointmentReservationAsync(DateTime date, string time, string AppointmentStatus)
        {
            throw new NotImplementedException();
        }
    }
}
