using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MyApi.Models;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //Esto es usado instead of this.context
        public PropietarioController(ApplicationDbContext context){
            _context = context;
        }

        [HttpGet("Index")] //Tipo de peticion
        public async Task<IActionResult> Index(){ //Numero de argumentos que recibe
            var listPropietario = await _context.Propietario.ToListAsync();
            if(listPropietario == null || listPropietario.Count == 0){
                return NoContent();    
            }else {
                return Ok(listPropietario);
            }
        }
        [HttpPost("Store")]
public async Task<HttpStatusCode> Store([FromBody] Propietario propietario)
{
    if (propietario == null)
    {
        return HttpStatusCode.BadRequest;
    }
    _context.Add(propietario);
    await _context.SaveChangesAsync();
    return HttpStatusCode.Created;
}

[HttpGet("Show")]
public async Task<IActionResult> Show(int id)
{
    var propietario = await _context.Propietario.FindAsync(id);
    if (propietario == null)
    {
        return NotFound();
    }
    return Ok(propietario);
}

[HttpDelete("Destroy")]
public async Task<IActionResult> Destroy(int id)
{
    var propietario = await _context.Propietario.FindAsync(id);
    if (propietario == null)
    {
        return NotFound();
    }
     _context.Propietario.Remove(propietario);
    await _context.SaveChangesAsync();
    return Ok();
}

[HttpPut("Update")]

public async Task<IActionResult> Update(int id, [FromBody] Propietario propietario){
    if(propietario ==null || propietario.Id != id){
        return BadRequest(); //400
    }
    var entity = await _context.Propietario.FindAsync(propietario.Id);
    if (entity == null){
        return NotFound(); //404
    }

    entity.Nombre = propietario.Nombre;
    entity.Apellidos = propietario.Apellidos;
    entity.Direccion = propietario.Direccion;
    entity.CorreoElectronico = propietario.CorreoElectronico;
    entity.Telefono = propietario.Telefono;
    await _context.SaveChangesAsync();
    return Ok();
    {
        
    }
}
        
    }
}