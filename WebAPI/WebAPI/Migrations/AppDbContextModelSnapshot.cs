﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Context;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Model.Categoria", b =>
                {
                    b.Property<long?>("CategoriasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("CategoriasId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriasId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriasId = 1L,
                            Nome = "Eletrônicos"
                        });
                });

            modelBuilder.Entity("WebAPI.Model.Produto", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<long?>("FK_CategoriaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("Preco")
                        .HasColumnType("int");

                    b.Property<int>("QntEstoque")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_CategoriaId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FK_CategoriaId = 1L,
                            Nome = "Smartphone",
                            Preco = 2000,
                            QntEstoque = 50
                        });
                });

            modelBuilder.Entity("WebAPI.Model.Produto", b =>
                {
                    b.HasOne("WebAPI.Model.Categoria", "Categorias")
                        .WithMany("Produtos")
                        .HasForeignKey("FK_CategoriaId");

                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("WebAPI.Model.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
