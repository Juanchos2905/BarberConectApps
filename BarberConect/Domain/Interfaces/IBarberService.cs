using BarberConect.DAL.Entities;
using System.Diagnostics.Metrics;

namespace BarberConect.Domain.Interfaces
{
    public interface IBarberService
    {
        Task<IEnumerable<User>> GetBarbersAsync();
        Task<User> CreateBarberAsync(User barber); // Rol se asigna internamente
        Task<User> EditBarberAsync(User barber);
        Task<User> GetBarberByIdAsync(Guid id);
        Task<User> DeleteBarberAsync(Guid id);
    }
}
