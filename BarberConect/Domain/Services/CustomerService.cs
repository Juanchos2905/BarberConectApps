using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;

namespace BarberConect.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<Customer> CreateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> DeleteCustomerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> EditCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
