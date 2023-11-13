using BarberConect.DAL.Entities;

namespace BarberConect.Domain.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> EditCustomerAsync(Customer customer);
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<Customer> DeleteCustomerAsync(Guid id);
    }
}
