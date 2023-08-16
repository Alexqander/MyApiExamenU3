namespace MyApi.Models
{
    public class Pedido
    {
        public int Id {get; set; }
        public DateTime FechaSolicitud {get; set; }

        public DateTime FechaEntrega{get;set;}
        public String? Direccion {get;set;}

        public String? TotalPagar{get;set;}
        public String? MetodoPago{get;set;}
    }
}