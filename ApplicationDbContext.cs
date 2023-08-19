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
        public DbSet<Propietario>? Propietario { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Propietario>().HasData(
            new Propietario()
            {
                Id = 1,
                Nombre = "Erik",
                Apellidos = "Tapia",
                Direccion = "UTEZ",
                CorreoElectronico = "ErikT@Utez",
                Telefono = "7772958888"
            }
        );
        }

    }
}