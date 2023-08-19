namespace MyApi.Models
{
    public class Paciente
    {
        public int Id {get; set; }
        public String? Nombre {get;set;}
        public String? Especie {get;set;}
        public String? Raza {get;set;}
        public int? Peso {get;set;}
        public DateTime? FechaNacimiento {get;set;}

    }
}