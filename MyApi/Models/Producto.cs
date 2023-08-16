using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
    public class Producto
    {
        public int Id {get; set; }
        public String? Nombre {get;set;}
        public String? Descripcion {get;set;}
        public String? Precio {get;set;}
        public String? Cantidad {get;set;}
    }
}