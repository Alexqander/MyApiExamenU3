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
       
        public DbSet<Medicamento>? Medicamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Medicamento>().HasData(
                new Medicamento()
                {
                    Id = 1,
                    Nombre = "Paracetamol",
                    Descripcion = "Analgésico y antipirético",
                    DosisRecomendada = "2g de paracetamol",
                    FormaAdministracion = "Solución oral",
                    Indicaciones="Tomar cada 8 horas durante 10 dias."
                }

            );

        }

    }
}