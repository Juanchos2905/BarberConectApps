using BarberConect.DAL.Entities;

namespace BarberConect.Domain.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role> GetRoleByIdAsync(int id);
    }
}
