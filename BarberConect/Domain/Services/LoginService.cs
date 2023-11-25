using BarberConect.DAL;
using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarberConect.Domain.Services
{
    public class LoginService : ILoginService
    {
        public readonly DataBaseContext _context;
        public LoginService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<User> GetLoginAsync(string email, string password)
        {
            return await _context.Users
           .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
