namespace MyApi.Models
{
    public class Categoria
    {
        public int Id {get; set; }
        public DateTime FechaCreacion {get; set; }
        public DateTime FechaActualizacion{get;set;}
        public String? Nombre {get;set;}
    }
}