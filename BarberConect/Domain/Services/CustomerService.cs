using BarberConect.DAL.Entities;
using BarberConect.DAL;
using BarberConect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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
                customer.RoleId = 2;
                if (customer.Age > 0 && customer.Age <= 100)
                {
                    _context.Users.Add(customer);
                    await _context.SaveChangesAsync();
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<User> DeleteCustomerAsync(Guid id)
        {
            try
            {
                var customer = await _context.Users
                    .FirstOrDefaultAsync(c => c.Id == id && c.RoleId == 2);
                if (customer == null) return null; // If the barber doesn't exists, it would return null.

                _context.Users.Remove(customer);
                await _context.SaveChangesAsync();

                return customer;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<User> EditCustomerAsync(User customer)
        {
            try
            {
                customer.ModifiedDate = DateTime.Now;
                customer.RoleId = 2;
                if (customer.Age > 0 && customer.Age <= 100)
                {
                    _context.Users.Update(customer);
                    await _context.SaveChangesAsync();
                    return customer;
                }
                else
                {
                    return null;
                }
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        //Solo sirve para el futuro...
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
