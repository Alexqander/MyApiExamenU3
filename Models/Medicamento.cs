using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
    public class Medicamento
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? DosisRecomendada { get; set; }
        public string? FormaAdministracion { get; set; }
        public string? Indicaciones { get; set; }
    }
}