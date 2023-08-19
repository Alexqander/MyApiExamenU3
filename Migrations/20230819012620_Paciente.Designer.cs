﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApi;

#nullable disable

namespace MyApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230819012620_Paciente")]
    partial class Paciente
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyApi.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Especie")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<int?>("Peso")
                        .HasColumnType("int");

                    b.Property<string>("Raza")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Paciente");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Especie = " Perro",
                            FechaNacimiento = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Guarumo",
                            Peso = 12,
                            Raza = "French Poodle"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
