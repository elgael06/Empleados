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
    public class ClientController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public ClientController(DemoDbContext context)
        {
            _context = context;
        }
        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientes() => await _context.Clientes.ToListAsync();
        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> getClient(int id)
        {
            var client = await _context.Clientes.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return client;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.id)
            {
                return BadRequest();
            }
            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                if (!ClientExist(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clientes.Add(client);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetClient", new { id = client.id }, client);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClient(int id)
        {
            var client = await _context.Clientes.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(client);
            await _context.SaveChangesAsync();
            return client;
        }
        private bool ClientExist(int id)
        {
            return _context.Clientes.Any(e => e.id == id);
        }
    }
}