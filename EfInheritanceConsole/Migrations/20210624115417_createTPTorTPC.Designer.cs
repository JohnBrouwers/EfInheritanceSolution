﻿// <auto-generated />
using EfInheritanceConsole.TPT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfInheritanceConsole.Migrations
{
    [DbContext(typeof(TPTPeopleDbContext))]
    [Migration("20210624115417_createTPTorTPC")]
    partial class createTPTorTPC
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfInheritanceConsole.TPT.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("EfInheritanceConsole.TPT.Entities.Customer", b =>
                {
                    b.HasBaseType("EfInheritanceConsole.TPT.Entities.Person");

                    b.Property<string>("CustomerNumber")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EfInheritanceConsole.TPT.Entities.Employee", b =>
                {
                    b.HasBaseType("EfInheritanceConsole.TPT.Entities.Person");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EfInheritanceConsole.TPT.Entities.Customer", b =>
                {
                    b.HasOne("EfInheritanceConsole.TPT.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("EfInheritanceConsole.TPT.Entities.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfInheritanceConsole.TPT.Entities.Employee", b =>
                {
                    b.HasOne("EfInheritanceConsole.TPT.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("EfInheritanceConsole.TPT.Entities.Employee", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
