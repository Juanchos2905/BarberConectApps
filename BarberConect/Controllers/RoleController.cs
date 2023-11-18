using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using BarberConect.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace BarberConect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _rolesService;
        public RoleController(IRoleService roleService)
        {
            _rolesService = roleService;
        }
        //GET BARBERS
        [HttpGet, ActionName("Get")]
        [Route("GetRoles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetCustomersAsync()
        {
            var roles = await _rolesService.GetCustomersAsync();
            if (roles == null || !roles.Any())
            {
                return NotFound();
            }

            return Ok(roles);
        }
        //GET BARBERS
        [HttpGet, ActionName("Get")]
        [Route("GetRolesById")]
        public async Task<ActionResult<IEnumerable<Role>>> GetCustomerByIdAsync(int id)
        {
            if (id == null) return BadRequest("Id es requerido!");

            var roles = await _rolesService.GetCustomerByIdAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }
    }
}
