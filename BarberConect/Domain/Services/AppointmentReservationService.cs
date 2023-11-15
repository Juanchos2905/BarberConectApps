using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;

namespace BarberConect.Domain.Services
{
    public class AppointmentReservationService : IAppointmentReservationService
    {
        public Task<AppointmentReservation> CreateAppointmentReservationAsync(AppointmentReservation appointmentReservation)
        {
            throw new NotImplementedException();
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
