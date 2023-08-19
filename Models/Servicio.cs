namespace MyApi.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }

        public String? Descripcion { get; set; }
        public Double? Costo { get; set; }

        public Double? DuracionEstimada { get; set; }
        public String? RequisistosPrevios { get; set; }
    }
}