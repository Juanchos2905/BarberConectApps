using BarberConect.DAL.Entities;

namespace BarberConect.Domain.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetCustomersAsync();
        Task<Role> GetCustomerByIdAsync(int id);
    }
}
