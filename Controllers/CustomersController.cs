using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resturangApi.Data;
using resturangApi.Dto.CustomerDtos;
using resturangApi.Models;
using resturangApi.Repositories.Interface;
using resturangApi.Services.Iservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resturangApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(IGenericRepository repo, IGenericItemService service) : ControllerBase
    {
        private readonly IGenericRepository _repo = repo;
        private readonly IGenericItemService _service = service;

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _repo.GetAll<Customer>();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _repo.GetItemByID<Customer>(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCustomer(int id, [FromBody]PatchCustomerDto dto)
        {
           var result = await _service.UpdateItem<Customer, PatchCustomerDto>(id, dto);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CreateCustomerDto customer)
        {
            var result = await _service.CreateItem<Customer, CreateCustomerDto>(customer);

            return CreatedAtAction("GetCustomer", new { id = result.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _service.DeleteItem<Customer>(id);
            if (result == false)
            {
                return NotFound();
            }

            return Ok("Customer Deleted");
        }

      
    }
}
