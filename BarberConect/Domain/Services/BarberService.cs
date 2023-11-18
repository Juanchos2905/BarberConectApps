using BarberConect.DAL;
using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BarberConect.Domain.Services
{
    public class BarberService : IBarberService
    {
        public readonly DataBaseContext _context;
        public BarberService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<User> CreateBarberAsync(User barber)
        {
            try
            {
                barber.Id = Guid.NewGuid();
                barber.CreateDate = DateTime.Now;
                _context.Users.Add(barber);
                await _context.SaveChangesAsync();
                return barber;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public Task<User> DeleteBarberAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> EditBarberAsync(User barber)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetBarberByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetBarbersAsync()
        {
                return await _context.Users
                .Where(u => u.RoleId == 1)
                .ToListAsync();
        }
    }
}
