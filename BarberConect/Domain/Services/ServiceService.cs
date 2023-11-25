using BarberConect.DAL;
using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberConect.Domain.Services
{
    public class ServiceService : IServiceService
    {
        public readonly DataBaseContext _context;
        public ServiceService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Service> CreateServiceAsync(Service service, Guid appointmentReservationId)
        {
            try
            {
                service.Id = Guid.NewGuid();
                service.CreateDate = DateTime.Now;
                service.AppointmentReservationId = appointmentReservationId;
                service.ModifiedDate = null;
                _context.Services.Add(service);
                await _context.SaveChangesAsync();
                return service;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Service> GetServiceByIdAsync(Guid id)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
        }


        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }
    }
}
