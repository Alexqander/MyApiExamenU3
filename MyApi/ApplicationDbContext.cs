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
        public DbSet<Cliente>? Cliente { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }

        public DbSet<Categoria>? Categoria { get; set; }


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
                    Descripcion = "pan",
                    Precio = "10",
                    Cantidad = "1"

                }

            );

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente()
                {
                    Id = 1,
                    Nombre = "Angel",
                    Apellidos = "Diaz Salgado",
                    RFC = "DISA020127SHD",
                    CorreoElectronico = "angel@outlook.com",
                    Telefono = "7775180616"

                }

            );
            modelBuilder.Entity<Proveedores>().HasData(
                new Proveedores()
                {
                    Id = 1,
                    NombreEmpresa = "Test",
                    NombreRepartidor = "Test",
                    CorreoElectronico = "correo@correo",
                    Telefono = "7775557794",

                }
            );
            modelBuilder.Entity<Categoria>().HasData(
            new Categoria()
            {
                Id = 1,
                Nombre = "Ventas",
                FechaCreacion = new DateTime(),
                FechaActualizacion = new DateTime()
            }
        );
        }

    }
}