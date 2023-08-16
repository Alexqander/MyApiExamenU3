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
    public class PedidosController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //Esto es usado instead of this.context
        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Index")] //Tipo de peticion
        public async Task<IActionResult> Index()
        { //Numero de argumentos que recibe
            var listComments = await _context.Pedidos.ToListAsync();
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
        public async Task<HttpStatusCode> Store([FromBody] Pedido pedido)
        {
            if (pedido == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(pedido);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }


        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }


        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Pedido pedido){
            if(pedido == null ){
                return BadRequest();
            }

            var entity = await _context.Pedidos.FindAsync(pedido.Id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.FechaSolicitud = pedido.FechaSolicitud;
            entity.FechaEntrega = pedido.FechaEntrega;
            entity.Direccion = pedido.Direccion;
            entity.TotalPagar = pedido.TotalPagar;
            entity.MetodoPago = pedido.MetodoPago;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}