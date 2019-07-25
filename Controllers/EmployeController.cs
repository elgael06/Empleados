using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empleados.Models;

namespace Empleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public EmployeController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/Employe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employe>>> GetEmpleados()
        {
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/Employe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetEmploye(int id)
        {
            var employe = await _context.Empleados.FindAsync(id);

            if (employe == null)
            {
                return NotFound();
            }

            return employe;
        }

        // PUT: api/Employe/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploye(int id, Employe employe)
        {
            if (id != employe.id)
            {
                return BadRequest();
            }

            _context.Entry(employe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employe
        [HttpPost]
        public async Task<ActionResult<Employe>> PostEmploye(Employe employe)
        {
            _context.Empleados.Add(employe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploye", new { id = employe.id }, employe);
        }

        // DELETE: api/Employe/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employe>> DeleteEmploye(int id)
        {
            var employe = await _context.Empleados.FindAsync(id);
            if (employe == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(employe);
            await _context.SaveChangesAsync();

            return employe;
        }

        private bool EmployeExists(int id)
        {
            return _context.Empleados.Any(e => e.id == id);
        }
    }
}
