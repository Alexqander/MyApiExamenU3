using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyApi.Models;


namespace MyApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Pedido>? Pedidos { get; set; }
        public DbSet<Producto>? Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().HasData(
                new Pedido()
                {
                    Id = 1,
                    FechaSolicitud = new DateTime(),
                    FechaEntrega = new DateTime(),
                    Direccion = "Prueb1",
                    TotalPagar = "200",
                    MetodoPago = "Tarjeta"
                }

            );
            modelBuilder.Entity<Producto>().HasData(
                new Producto()
                {
                    Id = 1,
                    Nombre = "Pan bimbo",
                    Descripcion="pan",
                    Precio="10",
                    Cantidad="1"

                }

            );
        }

    }
}