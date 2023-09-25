using System;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
	public class PersonDbContext : DbContext
    {
		public DbSet<Person> Persons { get; set; }
		public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Country>().ToTable("Countries");
        }
    }

	
}

