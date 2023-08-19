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
        public DbSet<Paciente>? Paciente { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Paciente>().HasData(
                new Paciente()
                {
                    Id = 1,
                    Nombre = "Guarumo",
                    Especie = " Perro",
                    Raza = "French Poodle",
                    Peso = 12,
                    FechaNacimiento = new DateTime()

                }

            );
        }

    }
}