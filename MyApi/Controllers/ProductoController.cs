using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //Esto es usado instead of this.context
        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("Index")] //Tipo de peticion
        public async Task<IActionResult> Index()
        { //Numero de argumentos que recibe
            var listProducts = await _context.Productos.ToListAsync();
            if (listProducts == null || listProducts.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(listProducts);
            }
        }
        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] Producto producto)
        {
            if (producto == null || producto.Id != id)
            {
                return BadRequest();

            }
            var entity = await _context.Productos.FindAsync(producto.Id);
            if (entity == null)
            {
                return NotFound();//404


            }
            entity.Nombre = producto.Nombre;
            entity.Descripcion = producto.Descripcion;
            entity.Precio = producto.Precio;
            entity.Cantidad = producto.Precio;
            await _context.SaveChangesAsync();
            return Ok();
        }




    }
}
