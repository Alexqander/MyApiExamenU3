using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MyApi.Models;
using Microsoft.AspNetCore.Cors;
using MyApi;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //Esto es usado instead of this.context
        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Index")] //Tipo de peticion
        public async Task<IActionResult> Index()
        { //Numero de argumentos que recibe
            var listClients = await _context.Cliente.ToListAsync();
            if (listClients == null || listClients.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(listClients);
            }
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }


        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }


        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Cliente cliente){
            if(cliente == null ){
                return BadRequest();
            }

            var entity = await _context.Cliente.FindAsync(cliente.Id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Nombre = cliente.Nombre;
            entity.Apellidos = cliente.Apellidos;
            entity.RFC = cliente.RFC;
            entity.CorreoElectronico = cliente.CorreoElectronico;
            entity.Telefono = cliente.Telefono;
            
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}