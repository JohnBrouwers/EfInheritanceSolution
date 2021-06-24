using EfInheritanceConsole.TPT.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EfInheritanceConsole.TPT
{
    public class TPTPeopleDbContext: DbContext
    {
        public DbSet<Person> People { get; set; }

        //public TPTPeopleDbContext(DbContextOptions<TPTPeopleDbContext> options): base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Opleidingen\EF\EfInheritanceSolution\EfInheritanceConsole\TPT\Data\TPTPeople.mdf;Integrated Security=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //EF Core, TPT or TPC?
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Employee>().ToTable("Employees");

            //EF 6:
            //modelBuilder.Entity<Customer>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Customers");
            //});

            //modelBuilder.Entity<Employee>().Map(m =>
            //{
            //    m.MapInheritedProperties();
            //    m.ToTable("Employees");
            //});
        }
    }
}
