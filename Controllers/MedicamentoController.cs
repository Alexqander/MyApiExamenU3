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

    public class MedicamentoController : ControllerBase
    {
        private readonly ApplicationDbContext _context; //Esto es usado instead of this.context
        public MedicamentoController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("Index")] //Tipo de peticion
        public async Task<IActionResult> Index()
        { //Numero de argumentos que recibe
            var listMedicamentos = await _context.Medicamentos.ToListAsync();
            if (listMedicamentos == null || listMedicamentos.Count == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(listMedicamentos);
            }
        }
        [HttpPost("Store")]
        public async Task<HttpStatusCode> Store([FromBody] Medicamento medicamento)
        {
            if (medicamento == null)
            {
                return HttpStatusCode.BadRequest;
            }
            _context.Add(medicamento);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }
        [HttpGet("Show")]
        public async Task<IActionResult> Show(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            return Ok(medicamento);
        }

        [HttpDelete("Destroy")]
        public async Task<IActionResult> Destroy(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            _context.Medicamentos.Remove(medicamento);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] Medicamento medicamento)
        {
            if (medicamento == null || medicamento.Id != id)
            {
                return BadRequest();

            }
            var entity = await _context.Medicamentos.FindAsync(medicamento.Id);
            if (entity == null)
            {
                return NotFound();//404


            }
            entity.Nombre = medicamento.Nombre;
            entity.Descripcion = medicamento.Descripcion;
            entity.DosisRecomendada = medicamento.DosisRecomendada;
            entity.FormaAdministracion = medicamento.FormaAdministracion;
            entity.Indicaciones = medicamento.Indicaciones;
            await _context.SaveChangesAsync();
            return Ok();
        }




    }
}
