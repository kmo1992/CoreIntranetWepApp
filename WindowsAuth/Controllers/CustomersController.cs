using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.DTOs;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WindowsAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly SampleContext _context;
        private readonly IMapper _mapper;

        public CustomersController(SampleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Customers
        [HttpGet]
        public async Task<IEnumerable<CustomerDTO>> GetCustomer()
        {
            var customers =  await _context.Customer.ToListAsync();
            return _mapper.Map<List<Customer>, IEnumerable<CustomerDTO>>(customers);
        }

        // GET: Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return _mapper.Map<CustomerDTO>(customer);
        }

        // PUT: Customers/5
        [HttpPut("{id}")]
        [Authorize(Roles = Shared.Roles.Admin)]
        public async Task<IActionResult> PutCustomer(int id, CustomerDTO model)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _mapper.Map<CustomerDTO, Customer>(model, customer);
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: Customers
        [HttpPost]
        [Authorize(Roles = Shared.Roles.Admin)]
        public async Task<ActionResult<CustomerDTO>> PostCustomer(CustomerDTO model)
        {
            var customer = _mapper.Map<Customer>(model);
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, _mapper.Map<CustomerDTO>(customer));
        }

        // DELETE: Customers/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Shared.Roles.Admin)]
        public async Task<ActionResult<CustomerDTO>> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
