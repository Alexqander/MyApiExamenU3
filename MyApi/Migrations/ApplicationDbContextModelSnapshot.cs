﻿// <auto-generated />
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

            modelBuilder.Entity("MyApi.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .HasColumnType("longtext");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("RFC")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cliente");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Diaz Salgado",
                            CorreoElectronico = "angel@outlook.com",
                            Nombre = "Angel",
                            RFC = "DISA020127SHD",
                            Telefono = "7775180616"
                        });
                });

            modelBuilder.Entity("MyApi.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaSolicitud")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MetodoPago")
                        .HasColumnType("longtext");

                    b.Property<string>("TotalPagar")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Direccion = "Prueb1",
                            FechaEntrega = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechaSolicitud = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MetodoPago = "Tarjeta",
                            TotalPagar = "200"
                        });
                });

            modelBuilder.Entity("MyApi.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cantidad")
                        .HasColumnType("longtext");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("Precio")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cantidad = "1",
                            Descripcion = "pan",
                            Nombre = "Pan bimbo",
                            Precio = "10"
                        });
                });

            modelBuilder.Entity("MyApi.Models.Proveedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("longtext");

                    b.Property<string>("NombreEmpresa")
                        .HasColumnType("longtext");

                    b.Property<string>("NombreRepartidor")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Proveedores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorreoElectronico = "correo@correo",
                            NombreEmpresa = "Test",
                            NombreRepartidor = "Test",
                            Telefono = "7775557794"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
