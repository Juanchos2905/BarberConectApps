using BarberConect.DAL.Entities;

namespace BarberConect.Domain.Interfaces
{
    public interface IAppointmentReservationService
    {
        Task<AppointmentReservation> CreateAppointmentReservationAsync(AppointmentReservation appointmentReservation, Guid userId);
        Task<AppointmentReservation> UpdateAppointmentReservationAsync(AppointmentReservation appointmentReservation);
        Task<AppointmentReservation> DeleteAppointmentReservationAsync(Guid id);
        Task<AppointmentReservation> ValidateAppointmentReservationAsync(DateTime date, string time, string AppointmentStatus);
    }
}
