using BarberConect.DAL.Entities;
using BarberConect.Domain.Interfaces;
using BarberConect.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace BarberConect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //GET CUSTOMERS
        [HttpGet, ActionName("Get")]
        [Route("GetCustomers")]
        public async Task<ActionResult<IEnumerable<User>>> GetCustomersAsync()
        {
            var customers = await _customerService.GetCustomersAsync();
            if (customers == null || !customers.Any())
            {
                return NotFound();
            }

            return Ok(customers);
        }
        //CREATE CUSTOMER 
        [HttpPost, ActionName("Create")]
        [Route("CreateCustomer")]
        public async Task<ActionResult> CreateCustomerAsync(User customer)
        {
            try
            {
                var createCustomer = await _customerService.CreateCustomerAsync(customer);
                if (createCustomer == null)
                {
                    return NotFound();
                }
                return Ok(createCustomer);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("El cliente {0} ya existe ", customer.Id));
                }
                return Conflict(ex.Message);
            }
        }

        //DELETE CUSTOMER
        [HttpDelete, ActionName("Delete")]
        [Route("DeleteCustomer")]
        public async Task<ActionResult<User>> DeleteCustomerAsync(Guid id)
        {
            if (id == null) return BadRequest("El id del cliente es requerido!");

            var deletedCustomer = await _customerService.DeleteCustomerAsync(id);
            if (deletedCustomer == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            return Ok(deletedCustomer);
        }

    }
}
