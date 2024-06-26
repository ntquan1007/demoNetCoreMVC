using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository;

namespace Repository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public CustomerController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = _unitOfWork.CustomerRepository.Get();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetByID(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _unitOfWork.CustomerRepository.Insert(customer);
            _unitOfWork.Save();
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _unitOfWork.CustomerRepository.Update(customer);
            _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = _unitOfWork.CustomerRepository.GetByID(id);
            if (customer == null)
            {
                return NotFound();
            }

            _unitOfWork.CustomerRepository.Delete(customer);
            _unitOfWork.Save();
            return NoContent();
        }
    }
}
