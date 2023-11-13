using BarberConect.DAL.Entities;
using System.Diagnostics.Metrics;

namespace BarberConect.Domain.Interfaces
{
    public interface IBarberService
    {
        Task<Barber> CreateBarberAsync(Barber barber);
        Task<Barber> EditBarberAsync(Barber barber);
        Task<Barber> GetBarberByIdAsync(Guid id);
        Task<Barber> DeleteBarberAsync(Guid id);
    }
}
