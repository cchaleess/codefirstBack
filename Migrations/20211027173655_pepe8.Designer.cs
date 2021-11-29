﻿// <auto-generated />
using System;
using CodeFirst.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeFirst.Migrations
{
    [DbContext(typeof(MVCContext))]
    [Migration("20211027173655_pepe8")]
    partial class pepe8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.1.21102.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeFirst.DBModels.Archivo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Archivo");
                });

            modelBuilder.Entity("CodeFirst.DBModels.Consulta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReferenciaID")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ReferenciaID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("CodeFirst.DBModels.Referencia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArchivoID")
                        .HasColumnType("int");

                    b.Property<string>("Ref")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnidadesPropuesta")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ArchivoID");

                    b.ToTable("Referencia");
                });

            modelBuilder.Entity("CodeFirst.DBModels.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("CodeFirst.DBModels.Consulta", b =>
                {
                    b.HasOne("CodeFirst.DBModels.Referencia", "Referencia")
                        .WithMany()
                        .HasForeignKey("ReferenciaID");

                    b.HasOne("CodeFirst.DBModels.Usuario", "Usuario")
                        .WithMany("Consultas")
                        .HasForeignKey("UsuarioID");

                    b.Navigation("Referencia");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("CodeFirst.DBModels.Referencia", b =>
                {
                    b.HasOne("CodeFirst.DBModels.Archivo", "Archivo")
                        .WithMany("Referencias")
                        .HasForeignKey("ArchivoID");

                    b.Navigation("Archivo");
                });

            modelBuilder.Entity("CodeFirst.DBModels.Archivo", b =>
                {
                    b.Navigation("Referencias");
                });

            modelBuilder.Entity("CodeFirst.DBModels.Usuario", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}