using BarberConect.DAL.Entities;

namespace BarberConect.Domain.Interfaces
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> GetServicesAsync();
        Task<Service> GetServiceByIdAsync(Guid id);
    }
}
