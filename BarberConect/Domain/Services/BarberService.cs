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

        public async Task<Barber> CreateBarberAsync(Barber barber)
        {
            try
            {
                barber.Id = Guid.NewGuid();
                barber.CreateDate = DateTime.Now;
                _context.Barbers.Add(barber);
                await _context.SaveChangesAsync();
                return barber;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public Task<Barber> DeleteBarberAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Barber> EditBarberAsync(Barber barber)
        {
            throw new NotImplementedException();
        }

        public Task<Barber> GetBarberByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Barber>> GetBarbersAsync()
        {
                return await _context.Barbers.ToListAsync();
        }
    }
}
