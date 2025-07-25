﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWheelsSql.Data;

#nullable disable

namespace MyWheelsSql.Migrations
{
    [DbContext(typeof(MyWhelssDbContext))]
    [Migration("20250614185057_EmailUnique")]
    partial class EmailUnique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyWheelsSql.Models.Aluguel", b =>
                {
                    b.Property<int>("AluguelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AluguelId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("AluguelId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Aluguels");
                });

            modelBuilder.Entity("MyWheelsSql.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MyWheelsSql.Models.Compra", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompraId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CompraId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("MyWheelsSql.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<int?>("AluguelId")
                        .HasColumnType("int");

                    b.Property<int?>("CompraId")
                        .HasColumnType("int");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoProduto")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("ProdutoId");

                    b.HasIndex("AluguelId");

                    b.HasIndex("CompraId");

                    b.ToTable("Produtos");

                    b.HasDiscriminator<string>("TipoProduto").HasValue("Produto");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MyWheelsSql.Models.Bicicleta", b =>
                {
                    b.HasBaseType("MyWheelsSql.Models.Produto");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Bicicleta");
                });

            modelBuilder.Entity("MyWheelsSql.Models.Peca", b =>
                {
                    b.HasBaseType("MyWheelsSql.Models.Produto");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Peca");
                });

            modelBuilder.Entity("MyWheelsSql.Models.Aluguel", b =>
                {
                    b.HasOne("MyWheelsSql.Models.Cliente", null)
                        .WithMany("Aluguels")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyWheelsSql.Models.Compra", b =>
                {
                    b.HasOne("MyWheelsSql.Models.Cliente", null)
                        .WithMany("Compras")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyWheelsSql.Models.Produto", b =>
                {
                    b.HasOne("MyWheelsSql.Models.Aluguel", "Aluguel")
                        .WithMany("Items")
                        .HasForeignKey("AluguelId");

                    b.HasOne("MyWheelsSql.Models.Compra", "Compra")
                        .WithMany("Produtos")
                        .HasForeignKey("CompraId");

                    b.Navigation("Aluguel");

                    b.Navigation("Compra");
                });

            modelBuilder.Entity("MyWheelsSql.Models.Aluguel", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("MyWheelsSql.Models.Cliente", b =>
                {
                    b.Navigation("Aluguels");

                    b.Navigation("Compras");
                });

            modelBuilder.Entity("MyWheelsSql.Models.Compra", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
