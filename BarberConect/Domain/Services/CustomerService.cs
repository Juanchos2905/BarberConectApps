using BarberConect.DAL.Entities;
using BarberConect.DAL;
using BarberConect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberConect.Domain.Services
{

    public class CustomerService : ICustomerService
    {
        public readonly DataBaseContext _context;
        public CustomerService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<User> CreateCustomerAsync(User customer)
        {
            try
            {
                customer.Id = Guid.NewGuid();
                customer.CreateDate = DateTime.Now;
                _context.Users.Add(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public Task<User> DeleteCustomerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> EditCustomerAsync(User barber)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetCustomerByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetCustomersAsync()
        {
            return await _context.Users
            .Where(u => u.RoleId == 2)
            .ToListAsync();
        }
    }
    
}
