using CRUDPersonCleanArchitecture.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRUDPersonCleanArchitecture
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().ToTable("People");
        }
    }
}


