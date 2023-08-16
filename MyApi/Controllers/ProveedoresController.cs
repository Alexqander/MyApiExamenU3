using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //Esto es usado instead of this.context
        public ProveedoresController(ApplicationDbContext context){
            _context = context;
        }

        [HttpGet("Index")] //Tipo de peticion
        public async Task<IActionResult> Index(){ //Numero de argumentos que recibe
            var listProveedores = await _context.Proveedores.ToListAsync();
            if(listProveedores == null || listProveedores.Count == 0){
                return NoContent();    
            }else {
                return Ok(listProveedores);
            }
        }
        [HttpPost("Store")]
public async Task<HttpStatusCode> Store([FromBody] Proveedores proveedor)
{
    if (proveedor == null)
    {
        return HttpStatusCode.BadRequest;
    }
    _context.Add(proveedor);
    await _context.SaveChangesAsync();
    return HttpStatusCode.Created;
}

[HttpGet("Show")]
public async Task<IActionResult> Show(int id)
{
    var proveedor = await _context.Proveedores.FindAsync(id);
    if (proveedor == null)
    {
        return NotFound();
    }
    return Ok(proveedor);
}

[HttpDelete("Destroy")]
public async Task<IActionResult> Destroy(int id)
{
    var proveedor = await _context.Proveedores.FindAsync(id);
    if (proveedor == null)
    {
        return NotFound();
    }
     _context.Proveedores.Remove(proveedor);
    await _context.SaveChangesAsync();
    return Ok();
}

[HttpPut("Update")]

public async Task<IActionResult> Update(int id, [FromBody] Proveedores proveedor){
    if(proveedor ==null || proveedor.Id != id){
        return BadRequest(); //400
    }
    var entity = await _context.Proveedores.FindAsync(proveedor.Id);
    if (entity == null){
        return NotFound(); //404
    }

    entity.NombreEmpresa = proveedor.NombreEmpresa;
    entity.NombreRepartidor = proveedor.NombreRepartidor;
    entity.CorreoElectronico = proveedor.CorreoElectronico;
    entity.Telefono = proveedor.Telefono;
    await _context.SaveChangesAsync();
    return Ok();
    {
        
    }
}
        
    }
}