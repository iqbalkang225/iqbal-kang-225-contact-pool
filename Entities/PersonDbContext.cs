using System;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
	public class PersonDbContext : DbContext
    {
		public DbSet<Person> Persons { get; set; }
		public DbSet<Country> Countries { get; set; }

        public PersonDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("Persons");
            modelBuilder.Entity<Country>().ToTable("Countries");

            modelBuilder.Entity<Person>().Property(temp => temp.TIN)
                .HasColumnName("TaxIdentificationNumer")
                .HasColumnType("varchar(8)")
                .HasDefaultValue("12345678");

            //seed data - Country
            string countriesJSON = System.IO.File.ReadAllText("countries.json");
            List<Country>? countries = System.Text.Json.JsonSerializer.Deserialize<List<Country>>(countriesJSON);

            foreach(Country country in countries)
                modelBuilder.Entity<Country>().HasData(country);

            string personsJSON = System.IO.File.ReadAllText("persons.json");
            List<Person> persons = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(personsJSON);

            foreach(Person person in persons)
                modelBuilder.Entity<Person>().HasData(person);

        }
    }

	
}

