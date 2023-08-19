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
    public class PacienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PacienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Index")] 
        public async Task<IActionResult> Index()
        { //Numero de argumentos que recibe
            var listPacientes = await _context.Paciente.ToListAsync();
            if (listPacientes == null || listPacientes.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(listPacientes);
            }
        }

        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Paciente Paciente)
        {
            if (Paciente == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(Paciente);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }


        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var Paciente = await _context.Paciente.FindAsync(id);
            if (Paciente == null)
            {
                return NotFound();
            }
            return Ok(Paciente);
        }


        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var Paciente = await _context.Paciente.FindAsync(id);
            if (Paciente == null)
            {
                return NotFound();
            }
            _context.Paciente.Remove(Paciente);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Paciente Paciente){
            if(Paciente == null ){
                return BadRequest();
            }

            var entity = await _context.Paciente.FindAsync(Paciente.Id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Nombre = Paciente.Nombre;
            entity.Especie = Paciente.Especie;
            entity.Raza = Paciente.Raza;
            entity.Peso = Paciente.Peso;
            entity.FechaNacimiento = Paciente.FechaNacimiento;
            
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}