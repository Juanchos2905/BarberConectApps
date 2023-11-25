using BarberConect.DAL.Entities;

namespace BarberConect.Domain.Interfaces
{
    public interface ILoginService
    {
        Task<User> GetLoginAsync(string email, string password);
    }
}
