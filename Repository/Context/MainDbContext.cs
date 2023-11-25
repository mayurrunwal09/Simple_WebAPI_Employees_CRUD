using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class MainDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Sallary> Sallaries { get; set; }
        public MainDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sallary>()
                .HasOne<Employee>(e => e.Employee)
                .WithMany(s => s.Sallaries)
                .HasForeignKey(s => s.Emp_ID)
                .IsRequired();

            modelBuilder.Entity<Sallary>()
                .HasOne<Department>(d => d.Department)
                .WithMany(s => s.Sallaries)
                .HasForeignKey(f => f.Dep_ID)
                .IsRequired();
        }
    }
}
