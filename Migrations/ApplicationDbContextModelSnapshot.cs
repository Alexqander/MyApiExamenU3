
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApi;

#nullable disable

namespace MyApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyApi.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double?>("Costo")
                        .HasColumnType("double");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<double?>("DuracionEstimada")
                        .HasColumnType("double");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("RequisistosPrevios")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Servicios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Costo = 100.0,
                            Descripcion = "Descripcion1",
                            DuracionEstimada = 100.09999999999999,
                            Nombre = "Servicio1",
                            RequisistosPrevios = "Ninguno"
                        });
                });
#pragma warning restore 612, 618

#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyApi.Models.Propietarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .HasColumnType("longtext");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Propietarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Tapia",
                            CorreoElectronico = "ErikT@Utez",
                            Direccion = "UTEZ",
                            Nombre = "Erik",
                            Telefono = "7772958888"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

