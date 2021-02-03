using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace covidipedia.front
{
    public partial class bddcovidipediaContext : DbContext
    {
        public string connectionString {get;}

        public bddcovidipediaContext() {}
        public bddcovidipediaContext(DbContextOptions<bddcovidipediaContext> options) : base(options) {}

        public virtual DbSet<AyantLesPathology> AyantLesPathologies { get; set; }
        public virtual DbSet<Ca> Cas { get; set; }
        public virtual DbSet<EffetSecondaire> EffetSecondaires { get; set; }
        public virtual DbSet<EstDiagnostique> EstDiagnostiques { get; set; }
        public virtual DbSet<HistoriqueCa> HistoriqueCas { get; set; }
        public virtual DbSet<Hopital> Hopitals { get; set; }
        public virtual DbSet<Localisation> Localisations { get; set; }
        public virtual DbSet<Pathologie> Pathologies { get; set; }
        public virtual DbSet<Personne> Personnes { get; set; }
        public virtual DbSet<RecoitLeTraitement> RecoitLeTraitements { get; set; }
        public virtual DbSet<RessentEffetSecondaire> RessentEffetSecondaires { get; set; }
        public virtual DbSet<Symptome> Symptomes { get; set; }
        public virtual DbSet<Traitement> Traitements { get; set; }
        public virtual DbSet<Vaccin> Vaccins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), false);
                IConfigurationRoot root = configurationBuilder.Build();
                optionsBuilder.UseNpgsql(root.GetSection("ConnectionString").Value);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_France.1252");

            modelBuilder.Entity<AyantLesPathology>(entity =>
            {
                entity.HasKey(e => new { e.IdPathologiePathologie, e.IdCasCas })
                    .HasName("ayant_les_pathologies_pkey");

                entity.ToTable("ayant_les_pathologies");

                entity.Property(e => e.IdPathologiePathologie)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_pathologie_pathologie");

                entity.Property(e => e.IdCasCas)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_cas_cas");

                entity.HasOne(d => d.IdCasCasNavigation)
                    .WithMany(p => p.AyantLesPathologies)
                    .HasForeignKey(d => d.IdCasCas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ayant_les_pathologies_id_cas_cas");

                entity.HasOne(d => d.IdPathologiePathologieNavigation)
                    .WithMany(p => p.AyantLesPathologies)
                    .HasForeignKey(d => d.IdPathologiePathologie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ayant_les_pathologies_id_pathologie_pathologie");
            });

            modelBuilder.Entity<Ca>(entity =>
            {
                entity.HasKey(e => e.IdCasCas)
                    .HasName("cas_pkey");

                entity.ToTable("cas");

                entity.Property(e => e.IdCasCas).HasColumnName("id_cas_cas");

                entity.Property(e => e.EtatActuelCas)
                    .HasMaxLength(100)
                    .HasColumnName("etat_actuel_cas")
                    .IsFixedLength(true);

                entity.Property(e => e.HopitalIdHopitalHopital)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("hopital_id_hopital_hopital");

                entity.Property(e => e.PersonneIdPersonnePersonne)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("personne_id_personne_personne");

                entity.HasOne(d => d.HopitalIdHopitalHopitalNavigation)
                    .WithMany(p => p.Cas)
                    .HasForeignKey(d => d.HopitalIdHopitalHopital)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cas_hopital_id_hopital_hopital");

                entity.HasOne(d => d.PersonneIdPersonnePersonneNavigation)
                    .WithMany(p => p.Cas)
                    .HasForeignKey(d => d.PersonneIdPersonnePersonne)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cas_personne_id_personne_personne");
            });

            modelBuilder.Entity<EffetSecondaire>(entity =>
            {
                entity.HasKey(e => e.IdEffetEffetSecondaire)
                    .HasName("effet_secondaire_pkey");

                entity.ToTable("effet_secondaire");

                entity.Property(e => e.IdEffetEffetSecondaire).HasColumnName("id_effet_effet_secondaire");

                entity.Property(e => e.NomEffetEffetSecondaire)
                    .HasMaxLength(100)
                    .HasColumnName("nom_effet_effet_secondaire")
                    .IsFixedLength(true);

                entity.Property(e => e.TypeEffetEffetSecondaire)
                    .HasMaxLength(100)
                    .HasColumnName("type_effet_effet_secondaire")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<EstDiagnostique>(entity =>
            {
                entity.HasKey(e => new { e.IdSymptomeSymptome, e.IdCasCas })
                    .HasName("est_diagnostique_pkey");

                entity.ToTable("est_diagnostique");

                entity.Property(e => e.IdSymptomeSymptome)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_symptome_symptome");

                entity.Property(e => e.IdCasCas)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_cas_cas");

                entity.HasOne(d => d.IdCasCasNavigation)
                    .WithMany(p => p.EstDiagnostiques)
                    .HasForeignKey(d => d.IdCasCas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_est_diagnostique_id_cas_cas");

                entity.HasOne(d => d.IdSymptomeSymptomeNavigation)
                    .WithMany(p => p.EstDiagnostiques)
                    .HasForeignKey(d => d.IdSymptomeSymptome)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_est_diagnostique_id_symptome_symptome");
            });

            modelBuilder.Entity<HistoriqueCa>(entity =>
            {
                entity.HasKey(e => e.IdHistoriqueHistoriqueCas)
                    .HasName("historique_cas_pkey");

                entity.ToTable("historique_cas");

                entity.Property(e => e.IdHistoriqueHistoriqueCas).HasColumnName("id_historique_historique_cas");

                entity.Property(e => e.DateDetectionHistoriqueCas)
                    .HasColumnType("date")
                    .HasColumnName("date_detection_historique_cas");

                entity.Property(e => e.DateMajHistoriqueCas)
                    .HasColumnType("date")
                    .HasColumnName("date_maj_historique_cas");

                entity.Property(e => e.EtatCasHistoriqueCas)
                    .HasMaxLength(100)
                    .HasColumnName("etat_cas_historique_cas")
                    .IsFixedLength(true);

                entity.Property(e => e.IdCasCas)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_cas_cas");

                entity.Property(e => e.SoucheVirusHistoriqueCas)
                    .HasMaxLength(50)
                    .HasColumnName("souche_virus_historique_cas")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdCasCasNavigation)
                    .WithMany(p => p.HistoriqueCas)
                    .HasForeignKey(d => d.IdCasCas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_historique_cas_id_cas_cas");
            });

            modelBuilder.Entity<Hopital>(entity =>
            {
                entity.HasKey(e => e.IdHopitalHopital)
                    .HasName("hopital_pkey");

                entity.HasIndex(e => e.NomHopital).HasDatabaseName("nom_hopital_index");

                entity.ToTable("hopital");

                entity.Property(e => e.IdHopitalHopital).HasColumnName("id_hopital_hopital");

                entity.Property(e => e.IdLocalisationLocalisation)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_localisation_localisation");

                entity.Property(e => e.NomHopital)
                    .HasMaxLength(100)
                    .HasColumnName("nom_hopital")
                    .IsFixedLength(true);

                entity.Property(e => e.NombreLitsHopital).HasColumnName("nombre_lits_hopital");

                entity.Property(e => e.NombreLitsReanimationHopital).HasColumnName("nombre_lits_reanimation_hopital");

                entity.HasOne(d => d.IdLocalisationLocalisationNavigation)
                    .WithMany(p => p.Hopitals)
                    .HasForeignKey(d => d.IdLocalisationLocalisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_hopital_id_localisation_localisation");
            });

            modelBuilder.Entity<Localisation>(entity =>
            {
                entity.HasKey(e => e.IdLocalisationLocalisation)
                    .HasName("localisation_pkey");

                entity.ToTable("localisation");

                entity.Property(e => e.IdLocalisationLocalisation).HasColumnName("id_localisation_localisation");

                entity.Property(e => e.DepartementLocalisation).HasColumnName("departement_localisation");

                entity.Property(e => e.RegionLocalisation)
                    .HasMaxLength(100)
                    .HasColumnName("region_localisation")
                    .IsFixedLength(true);

                entity.Property(e => e.VilleLocalisation)
                    .HasMaxLength(100)
                    .HasColumnName("ville_localisation")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Pathologie>(entity =>
            {
                entity.HasKey(e => e.IdPathologiePathologie)
                    .HasName("pathologie_pkey");

                entity.ToTable("pathologie");

                entity.Property(e => e.IdPathologiePathologie).HasColumnName("id_pathologie_pathologie");

                entity.Property(e => e.NomPathologiePathologie)
                    .HasMaxLength(100)
                    .HasColumnName("nom_pathologie_pathologie")
                    .IsFixedLength(true);

                entity.Property(e => e.TypePathologiePathologie)
                    .HasMaxLength(100)
                    .HasColumnName("type_pathologie_pathologie")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Personne>(entity =>
            {
                entity.HasKey(e => e.IdPersonnePersonne)
                    .HasName("personne_pkey");

                entity.ToTable("personne");

                entity.Property(e => e.IdPersonnePersonne).HasColumnName("id_personne_personne");

                entity.Property(e => e.AgePersonne).HasColumnName("age_personne");

                entity.Property(e => e.DateVaccin1Personne)
                    .HasColumnType("date")
                    .HasColumnName("date_vaccin_1_personne");

                entity.Property(e => e.DateVaccin2Personne)
                    .HasColumnType("date")
                    .HasColumnName("date_vaccin_2_personne");

                entity.Property(e => e.EthniePersonne)
                    .HasMaxLength(100)
                    .HasColumnName("ethnie_personne")
                    .IsFixedLength(true);

                entity.Property(e => e.IdLocalisationLocalisation)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_localisation_localisation");

                entity.Property(e => e.IdentifiantPersonne)
                    .HasMaxLength(32)
                    .HasColumnName("identifiant_personne")
                    .IsFixedLength(true);

                entity.Property(e => e.SexePersonne).HasColumnName("sexe_personne");

                entity.Property(e => e.VaccinIdVaccinVaccin)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("vaccin_id_vaccin_vaccin");

                entity.HasOne(d => d.IdLocalisationLocalisationNavigation)
                    .WithMany(p => p.Personnes)
                    .HasForeignKey(d => d.IdLocalisationLocalisation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_personne_id_localisation_localisation");

                entity.HasOne(d => d.VaccinIdVaccinVaccinNavigation)
                    .WithMany(p => p.Personnes)
                    .HasForeignKey(d => d.VaccinIdVaccinVaccin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_personne_vaccin_id_vaccin_vaccin");
            });

            modelBuilder.Entity<RecoitLeTraitement>(entity =>
            {
                entity.HasKey(e => new { e.IdTraitementTraitement, e.IdCasCas })
                    .HasName("recoit_le_traitement_pkey");

                entity.ToTable("recoit_le_traitement");

                entity.Property(e => e.IdTraitementTraitement)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_traitement_traitement");

                entity.Property(e => e.IdCasCas)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_cas_cas");

                entity.HasOne(d => d.IdCasCasNavigation)
                    .WithMany(p => p.RecoitLeTraitements)
                    .HasForeignKey(d => d.IdCasCas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recoit_le_traitement_id_cas_cas");

                entity.HasOne(d => d.IdTraitementTraitementNavigation)
                    .WithMany(p => p.RecoitLeTraitements)
                    .HasForeignKey(d => d.IdTraitementTraitement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recoit_le_traitement_id_traitement_traitement");
            });

            modelBuilder.Entity<RessentEffetSecondaire>(entity =>
            {
                entity.HasKey(e => new { e.IdEffetEffetSecondaire, e.IdPersonnePersonne })
                    .HasName("ressent_effet_secondaire_pkey");

                entity.ToTable("ressent_effet_secondaire");

                entity.Property(e => e.IdEffetEffetSecondaire)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_effet_effet_secondaire");

                entity.Property(e => e.IdPersonnePersonne)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_personne_personne");

                entity.HasOne(d => d.IdEffetEffetSecondaireNavigation)
                    .WithMany(p => p.RessentEffetSecondaires)
                    .HasForeignKey(d => d.IdEffetEffetSecondaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ressent_effet_secondaire_id_effet_effet_secondaire");

                entity.HasOne(d => d.IdPersonnePersonneNavigation)
                    .WithMany(p => p.RessentEffetSecondaires)
                    .HasForeignKey(d => d.IdPersonnePersonne)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ressent_effet_secondaire_id_personne_personne");
            });

            modelBuilder.Entity<Symptome>(entity =>
            {
                entity.HasKey(e => e.IdSymptomeSymptome)
                    .HasName("symptome_pkey");

                entity.ToTable("symptome");

                entity.Property(e => e.IdSymptomeSymptome).HasColumnName("id_symptome_symptome");

                entity.Property(e => e.NomSymptomeSymptome)
                    .HasMaxLength(100)
                    .HasColumnName("nom_symptome_symptome")
                    .IsFixedLength(true);

                entity.Property(e => e.TypeSymptomeSymptome)
                    .HasMaxLength(100)
                    .HasColumnName("type_symptome_symptome")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Traitement>(entity =>
            {
                entity.HasKey(e => e.IdTraitementTraitement)
                    .HasName("traitement_pkey");

                entity.ToTable("traitement");

                entity.Property(e => e.IdTraitementTraitement).HasColumnName("id_traitement_traitement");

                entity.Property(e => e.NomTraitementTraitement)
                    .HasMaxLength(100)
                    .HasColumnName("nom_traitement_traitement")
                    .IsFixedLength(true);

                entity.Property(e => e.TypeTraitementTraitement)
                    .HasMaxLength(100)
                    .HasColumnName("type_traitement_traitement")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Vaccin>(entity =>
            {
                entity.HasKey(e => e.IdVaccinVaccin)
                    .HasName("vaccin_pkey");

                entity.ToTable("vaccin");

                entity.Property(e => e.IdVaccinVaccin).HasColumnName("id_vaccin_vaccin");

                entity.Property(e => e.FabricantVaccin)
                    .HasMaxLength(100)
                    .HasColumnName("fabricant_vaccin")
                    .IsFixedLength(true);

                entity.Property(e => e.NomVaccinVaccin)
                    .HasMaxLength(100)
                    .HasColumnName("nom_vaccin_vaccin")
                    .IsFixedLength(true);

                entity.Property(e => e.TypeVaccinVaccin)
                    .HasMaxLength(100)
                    .HasColumnName("type_vaccin_vaccin")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
