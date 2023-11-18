using BarberConect.DAL;
using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberConect.Domain.Services
{
    public class RoleService : IRoleService
    {
        public readonly DataBaseContext _context;
        public RoleService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Role> GetCustomerByIdAsync(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
            ;
        }

        public async Task<IEnumerable<Role>> GetCustomersAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
