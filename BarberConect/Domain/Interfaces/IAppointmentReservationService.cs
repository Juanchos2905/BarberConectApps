using BarberConect.DAL.Entities;

namespace BarberConect.Domain.Interfaces
{
    public interface IAppointmentReservationService
    {
        Task<AppointmentReservation> CreateAppointmentReservationAsync(AppointmentReservation appointmentReservation, Guid userId);
        Task<IEnumerable<AppointmentReservation>> GetAppointmentReservationsAsync();
        Task<IEnumerable <AppointmentReservation>> GetAppointmentReservationByDayAsync(DateTime date);
        Task<AppointmentReservation> UpdateAppointmentReservationAsync(Guid id); //Cancelar cita
        Task<AppointmentReservation> ValidateAppointmentReservationAsync(DateTime date, string time);
    }
}
