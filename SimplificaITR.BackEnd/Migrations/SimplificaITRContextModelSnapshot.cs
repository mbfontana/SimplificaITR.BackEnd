﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimplificaITR.BackEnd.Data;

#nullable disable

namespace SimplificaITR.BackEnd.Migrations
{
    [DbContext(typeof(SimplificaITRContext))]
    partial class SimplificaITRContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ConditionId")
                        .HasColumnType("int");

                    b.Property<double>("Metreage")
                        .HasColumnType("double");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CPF")
                        .HasColumnType("double");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CityRefId")
                        .HasColumnType("int");

                    b.Property<int>("ClienetRefId")
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Nirf")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Cpf")
                        .HasColumnType("double");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Area", b =>
                {
                    b.HasOne("SimplificaITR.BackEnd.Models.Condition", "Condition")
                        .WithMany("Areas")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimplificaITR.BackEnd.Models.Property", "Property")
                        .WithMany("Areas")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Cliente", b =>
                {
                    b.HasOne("SimplificaITR.BackEnd.Models.User", "User")
                        .WithMany("Clientes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Condition", b =>
                {
                    b.HasOne("SimplificaITR.BackEnd.Models.City", null)
                        .WithMany("Conditions")
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Property", b =>
                {
                    b.HasOne("SimplificaITR.BackEnd.Models.City", "City")
                        .WithMany("Properties")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimplificaITR.BackEnd.Models.Cliente", "Cliente")
                        .WithMany("Properties")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.City", b =>
                {
                    b.Navigation("Conditions");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Cliente", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Condition", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.Property", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("SimplificaITR.BackEnd.Models.User", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
