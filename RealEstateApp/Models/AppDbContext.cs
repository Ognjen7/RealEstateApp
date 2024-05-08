using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RealEstateApp.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Agent> Agenti { get; set; }
        public DbSet<Nekretnina> Nekretnine { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().HasData(
                new Agent() { Id = 1, ImeIPrezime = "Petar Pavlovic ", Licenca = "Lic1", GodinaRodjenja = 1960, BrojProdatihNekretnina = 15 },
                new Agent() { Id = 2, ImeIPrezime = "Nikolina Markovic ", Licenca = "Lic2", GodinaRodjenja = 1970, BrojProdatihNekretnina = 10 },
                new Agent() { Id = 3, ImeIPrezime = "Jovana Matic ", Licenca = "Lic3", GodinaRodjenja = 1980, BrojProdatihNekretnina = 5 }

            );

            modelBuilder.Entity<Nekretnina>().HasData(
                new Nekretnina() { Id = 1, Mesto = "Novi Sad", AgencijskaOznaka = "Nek01", GodinaIzgradnje = 1974, Kvadratura = 50, Cena = 40000, AgentId = 1 },
                new Nekretnina() { Id = 2, Mesto = "Beograd", AgencijskaOznaka = "Nek02", GodinaIzgradnje = 1990, Kvadratura = 60, Cena = 50000, AgentId = 2 },
                new Nekretnina() { Id = 3, Mesto = "Subotica", AgencijskaOznaka = "Nek03", GodinaIzgradnje = 1995, Kvadratura = 55, Cena = 45000, AgentId = 3 },
                new Nekretnina() { Id = 4, Mesto = "Zrenjanin", AgencijskaOznaka = "Nek04", GodinaIzgradnje = 2010, Kvadratura = 70, Cena = 60000, AgentId = 1 },
                new Nekretnina() { Id = 5, Mesto = "Novi Sad", AgencijskaOznaka = "Nek05", GodinaIzgradnje = 1974, Kvadratura = 50, Cena = 70000, AgentId = 1 },
                new Nekretnina() { Id = 6, Mesto = "Beograd", AgencijskaOznaka = "Nek06", GodinaIzgradnje = 2020, Kvadratura = 60, Cena = 150000, AgentId = 2 },
                new Nekretnina() { Id = 7, Mesto = "Subotica", AgencijskaOznaka = "Nek07", GodinaIzgradnje = 2005, Kvadratura = 75, Cena = 145000, AgentId = 3 },
                new Nekretnina() { Id = 8, Mesto = "Beograd", AgencijskaOznaka = "Nek08", GodinaIzgradnje = 2010, Kvadratura = 70, Cena = 170000, AgentId = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
