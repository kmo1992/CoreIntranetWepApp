using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Data;
using Shared.DTOs;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeyAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ApiKeyAuth]
    public class SuppliersController : ControllerBase
    {
        private readonly SampleContext _context;
        private readonly IMapper _mapper;

        public SuppliersController(SampleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Suppliers
        [HttpGet]
        public async Task<IEnumerable<SupplierDTO>> GetSupplier()
        {
            var suppliers = await _context.Supplier.ToListAsync();
            return _mapper.Map<List<Supplier>, IEnumerable<SupplierDTO>>(suppliers);
        }

        // GET: Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDTO>> GetSupplier(int id)
        {
            var supplier = await _context.Supplier.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return _mapper.Map<SupplierDTO>(supplier);
        }

        // PUT: Suppliers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, SupplierDTO model)
        {
            var supplier = await _context.Supplier.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            _mapper.Map<SupplierDTO, Supplier>(model, supplier);
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    
        // POST: Suppliers
        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> PostSupplier(SupplierDTO model)
        {
            var supplier = _mapper.Map<Supplier>(model);
            _context.Supplier.Add(supplier);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSupplier", new { id = supplier.Id }, _mapper.Map<SupplierDTO>(supplier));
        }

        // DELETE: Suppliers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupplierDTO>> DeleteSupplier(int id)
        {
            var supplier = await _context.Supplier.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Supplier.Remove(supplier);
            await _context.SaveChangesAsync();
            return _mapper.Map<SupplierDTO>(supplier);
        }
    }
}
