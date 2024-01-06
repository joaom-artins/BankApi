﻿// <auto-generated />
using System;
using Bank.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240106140055_segundaMIgracao")]
    partial class segundaMIgracao
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bank.Model.LegalPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("double");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("CorporateReason")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FantasyName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Number")
                        .HasMaxLength(7)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LegalPersons");
                });

            modelBuilder.Entity("Bank.Model.PhysicalPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasPrecision(18, 2)
                        .HasColumnType("double");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Number")
                        .HasMaxLength(7)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PhysicalPersons");
                });
#pragma warning restore 612, 618
        }
    }
}
