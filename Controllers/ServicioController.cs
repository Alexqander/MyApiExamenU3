using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MyApi.Models;
using Microsoft.AspNetCore.Cors;

namespace MyApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ServicioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Index")] //Peticion Get para mostrar todos los servicios
        public async Task<IActionResult> Index()
        { //Numero de argumentos que recibe
            var listComments = await _context.Servicios.ToListAsync();
            if (listComments == null || listComments.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(listComments);
            }
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Servicio Servicio)
        {
            if (Servicio == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(Servicio);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }


        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var Servicio = await _context.Servicios.FindAsync(id);
            if (Servicio == null)
            {
                return NotFound();
            }
            return Ok(Servicio);
        }


        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var Servicio = await _context.Servicios.FindAsync(id);
            if (Servicio == null)
            {
                return NotFound();
            }
            _context.Servicios.Remove(Servicio);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Servicio Servicio)
        {
            if (Servicio == null)
            {
                return BadRequest();
            }

            var entity = await _context.Servicios.FindAsync(Servicio.Id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Nombre = Servicio.Nombre;
            entity.Descripcion = Servicio.Descripcion;
            entity.Costo = Servicio.Costo;
            entity.DuracionEstimada = Servicio.DuracionEstimada;
            entity.RequisistosPrevios = Servicio.RequisistosPrevios;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}