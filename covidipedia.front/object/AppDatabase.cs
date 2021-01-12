using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace covidipedia.front
{
    public class AppDatabase : DbContext
    {
        public DbSet<Cas> Cas { get; set; }
        public DbSet<Hopital> Hopital { get; set; }
        public DbSet<Localisation> Localisation { get; set; }
        public DbSet<Symptomes> Symptomes { get; set; }
        public DbSet<Vaccin> Vaccin { get; set; }
        public DbSet<Pathologie> Pathologie { get; set; }
        public DbSet<Personne> Personne { get; set; }
        public DbSet<Est_diagnostique> Est_diagnostique { get; set; }
        public DbSet<A_pathologie> A_pathologie { get; set; }
        public DbSet<Ressent_effets_secondaires> Ressent_effets_secondaires { get; set; }
        public DbSet<Effets_secondaires> Effets_Secondaires {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=benis;Username=postgres;Password=aix en provence");

        public AppDatabase(DbContextOptions<AppDatabase> options) : base(options)
        {
            
        }
    }
}