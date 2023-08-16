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
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //Esto es usado instead of this.context
        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Index")] //Tipo de peticion
        public async Task<IActionResult> Index()
        { //Numero de argumentos que recibe
            var listCategorys = await _context.Categoria.ToListAsync();
            if (listCategorys == null || listCategorys.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(listCategorys);
            }
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }


        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }


        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Categoria categoria){
            if(categoria == null ){
                return BadRequest();
            }

            var entity = await _context.Categoria.FindAsync(categoria.Id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Nombre = categoria.Nombre;
            entity.FechaCreacion = categoria.FechaCreacion;
            entity.FechaActualizacion = categoria.FechaActualizacion;
            
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}