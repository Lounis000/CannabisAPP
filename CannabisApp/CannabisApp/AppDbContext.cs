using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CannabisApp
{
    class AppDbContext : DbContext
    {
        public DbSet<utilisateur> utilisateurs { get; set; }
        public DbSet<provenances> provenances { get; set; }
        public DbSet<inventaire> inventaire { get; set; }
        public DbSet<plantes> plantes { get; set; }
        public DbSet<historique_plantes> historique_plantes { get; set; }
        public DbSet<roles> roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-OE30FRF\\SQLEXPRESS;Database=NomDeLaBaseDeDonnées;Integrated Security=True;",
                 sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
             );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {// Configurer l'entité 'provenances'
            modelBuilder.Entity<provenances>()
                .HasKey(p => p.id_provenance);

            // Configurer l'entité 'historique_plantes'
            modelBuilder.Entity<historique_plantes>()
                .HasKey(h => h.id_historique);
            modelBuilder.Entity<historique_plantes>()
                .HasOne<utilisateur>()
                .WithMany()
                .HasForeignKey(h => h.id_utilisateur)
                .OnDelete(DeleteBehavior.Restrict); // Relation avec 'utilisateurs'
            modelBuilder.Entity<historique_plantes>()
                .HasOne<plantes>()
                .WithMany()
                .HasForeignKey(h => h.id_plante)
                .OnDelete(DeleteBehavior.Restrict); // Relation avec 'plantes'

            // Configurer l'entité 'roles'
            modelBuilder.Entity<roles>()
                .HasKey(r => r.id_role);

            // Configurer l'entité 'plantes'
            modelBuilder.Entity<plantes>()
                .HasKey(p => p.id_plante);
            modelBuilder.Entity<plantes>()
                .HasOne<provenances>()
                .WithMany()
                .HasForeignKey(p => p.id_provenance)
                .OnDelete(DeleteBehavior.Cascade); // Relation avec 'provenances'

            // Configurer l'entité 'inventaire'
            modelBuilder.Entity<inventaire>()
                .HasKey(i => i.id_inventaire);
            modelBuilder.Entity<inventaire>()
                .HasOne<plantes>()
                .WithMany()
                .HasForeignKey(i => i.id_plante)
                .OnDelete(DeleteBehavior.Cascade); // Relation avec 'plantes'

            // Configurer l'entité 'utilisateurs'
            modelBuilder.Entity<utilisateur>()
                .HasKey(u => u.id_utilisateur);
            modelBuilder.Entity<utilisateur>()
                .HasOne<roles>()
                .WithMany()
                .HasForeignKey(u => u.id_role)
                .OnDelete(DeleteBehavior.Restrict); // Relation avec 'roles'

        }
    }
}
