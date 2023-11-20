using BarberConect.DAL.Entities;

namespace BarberConect.Domain.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<User>> GetCustomersAsync();
        Task<User> CreateCustomerAsync(User customer); //Rol se asigna internamente
        Task<User> EditCustomerAsync(User customer);
        Task<User> GetCustomerByIdAsync(Guid id);
        Task<User> DeleteCustomerAsync(Guid id);
    }
}
