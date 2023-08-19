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
        public DbSet<Servicio>? Servicios { get; set; }
        public DbSet<Paciente>? Pacientes { get; set; }

        public DbSet<Propietario>? Propietarios { get; set; }

        public DbSet<Medicamento>? Medicamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Servicio>().HasData(
                new Servicio()
                {
                    Id = 1,
                    Nombre = "Servicio1",
                    Descripcion = "Descripcion1",
                    Costo = 100.0,
                    DuracionEstimada = 100.1,
                    RequisistosPrevios = "Ninguno"
                }

            );

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


            modelBuilder.Entity<Medicamento>().HasData(
                            new Medicamento()
                            {
                                Id = 1,
                                Nombre = "Paracetamol",
                                Descripcion = "Analgésico y antipirético",
                                DosisRecomendada = "2g de paracetamol",
                                FormaAdministracion = "Solución oral",
                                Indicaciones = "Tomar cada 8 horas durante 10 dias."
                            }

                        );

        }

    }

}
