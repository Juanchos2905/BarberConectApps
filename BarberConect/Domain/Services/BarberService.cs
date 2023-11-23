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
                barber.RoleId = 1;
                if (barber.Age > 0 && barber.Age <= 100)
                {
                    _context.Users.Add(barber);
                    await _context.SaveChangesAsync();
                    return barber;
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

        public async Task<User> DeleteBarberAsync(Guid id)
        {
            try
            {
                var barber = await _context.Users
                    .FirstOrDefaultAsync(b => b.Id == id && b.RoleId == 1);
                if (barber == null) return null; // If the barber doesn't exists, it would return null.

                _context.Users.Remove(barber);
                await _context.SaveChangesAsync();

                return barber;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<User> EditBarberAsync(User barber)
        {
            try
            {
                barber.ModifiedDate = DateTime.Now;
                barber.RoleId = 1;
                if (barber.Age > 0 && barber.Age <= 100)
                {
                    _context.Users.Update(barber);
                    await _context.SaveChangesAsync();
                    return barber;
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

        //Pensado pa futuro...
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
