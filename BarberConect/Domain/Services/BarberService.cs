using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;

namespace BarberConect.Domain.Services
{
    public class BarberService : IBarberService
    {
        public Task<Barber> CreateBarberAsync(Barber barber)
        {
            throw new NotImplementedException();
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
    }
}
