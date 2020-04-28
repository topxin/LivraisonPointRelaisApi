using System;
using HistoriqueAffectation.Model.Entites;
using HistoriqueAffectation.Model.Entites.Reference;
using Microsoft.EntityFrameworkCore;

namespace HistoriqueAffectation.Model.Data
{
    public class LivraisonPointRelaisDbContext: DbContext
    {
        public LivraisonPointRelaisDbContext(DbContextOptions<LivraisonPointRelaisDbContext> options): base(options)
        {
            
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PointRelais> PointsRelais { get; set; }
        public DbSet<Livraison> Livraisons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>().Property(x => x.NumeroCommande).IsRequired().HasMaxLength(8);
            modelBuilder.Entity<Produit>().Property(x => x.SiteMarchandise).IsRequired();
            modelBuilder.Entity<Produit>().Property(x => x.Nom).IsRequired();

            modelBuilder.Entity<Client>().Property(x => x.Nom).IsRequired();
            modelBuilder.Entity<Client>().Property(x => x.Prenom).IsRequired();

            modelBuilder.Entity<PointRelais>().Property(x => x.IdPointRelais).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<PointRelais>().Property(x => x.LibelleCommercial).IsRequired();

            modelBuilder.Entity<Livraison>().Property(x => x.Date).IsRequired();

            modelBuilder.Entity<Produit>()
                .HasOne(l => l.Client)
                .WithMany(p => p.produits)
                .HasForeignKey(l => l.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Produit>()
                .HasOne(x => x.Livraison)
                .WithOne(x => x.Produit)
                .HasForeignKey<Livraison>(x => x.IdProduit);

            modelBuilder.Entity<Livraison>()
                .HasOne(x => x.PointRelais)
                .WithMany(x => x.Livraisons)
                .HasForeignKey(x => x.IdPointRelais);

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = Guid.Parse("cec5d75e-0b5c-400b-a892-5f0cce618ee8"),
                    Nom = "Cruiz",
                    Prenom = "Tom",
                    Sexe = Sexe.M
                },
                new Client
                {
                    Id = Guid.Parse("cec5d75e-0b5c-400b-a892-5f0cce618ee9"),
                    Nom = "Kidman",
                    Prenom = "Nicole",
                    Sexe = Sexe.F
                },
                new Client
                {
                    Id = Guid.Parse("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"),
                    Nom = "Brad",
                    Prenom = "Pit",
                    Sexe = Sexe.M
                }
            );

            modelBuilder.Entity<Produit>().HasData(
                new Produit
                {
                    Id = Guid.Parse("ec38084f-7c33-4a96-84f2-91939c0fe819"),
                    ClientId = Guid.Parse("cec5d75e-0b5c-400b-a892-5f0cce618ee8"),
                    NumeroCommande = "4H7JK8F",
                    SiteMarchandise = "AbDiscount.com",
                    Nom = "IRobot Model S"
                },
                new Produit
                {
                    Id = Guid.Parse("02d686c5-dc32-4bc2-950e-32ecfd41fe9d"),
                    ClientId = Guid.Parse("cec5d75e-0b5c-400b-a892-5f0cce618ee9"),
                    NumeroCommande = "4H0AK8F",
                    SiteMarchandise = "Amazonia.fr",
                    Nom = "Drone enfant 4 hélices"
                },
                new Produit
                {
                    Id = Guid.Parse("91a0fb8a-e7bf-432c-bd34-e197f858ad6e"),
                    ClientId = Guid.Parse("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"),
                    NumeroCommande = "4U7JK8F",
                    SiteMarchandise = "BestBuy.eu",
                    Nom = "Canapé Angle",
                }
            );

            modelBuilder.Entity<PointRelais>().HasData(
                new PointRelais
                {
                    Id = Guid.Parse("a9731552-6219-47ae-99b1-d574bcbc399d"),
                    IdPointRelais = "11111111",
                    Gestionnaire = "JEROME",
                    LibelleCommercial = "Top Shop"
                },
                new PointRelais
                {
                    Id = Guid.Parse("a8d28d5f-8a98-423f-a4a0-6232db993b24"),
                    IdPointRelais = "2222222",
                    Gestionnaire = "CELINE",
                    LibelleCommercial = "Wonderful Prix"
                },
                new PointRelais
                {
                    Id = Guid.Parse("7b476381-8356-4c38-999f-d442ed944b50"),
                    IdPointRelais = "33333333",
                    Gestionnaire = "TIMOTHEE",
                    LibelleCommercial = "Good Phone"
                }
            );

            modelBuilder.Entity<Livraison>().HasData(
                new Livraison
                {
                    Id = Guid.Parse("c613c52f-a8c9-47b1-99d5-ce0e75e0de30"),
                    Date = new DateTime(2019, 10, 15),
                    IdProduit = Guid.Parse("ec38084f-7c33-4a96-84f2-91939c0fe819"),
                    IdPointRelais = Guid.Parse("a9731552-6219-47ae-99b1-d574bcbc399d"),
                },
                new Livraison
                {
                    Id = Guid.Parse("f23ce297-5baf-47a9-947b-417bbf80db13"),
                    Date = new DateTime(2020, 1, 3),
                    IdProduit = Guid.Parse("02d686c5-dc32-4bc2-950e-32ecfd41fe9d"),
                    IdPointRelais = Guid.Parse("a8d28d5f-8a98-423f-a4a0-6232db993b24"),
                },
                new Livraison
                {
                    Id = Guid.Parse("98932b8f-572e-4390-87c2-c59c8c836b67"),
                    Date = new DateTime(2019, 10, 15),
                    IdProduit = Guid.Parse("91a0fb8a-e7bf-432c-bd34-e197f858ad6e"),
                    IdPointRelais = Guid.Parse("7b476381-8356-4c38-999f-d442ed944b50"),
                }
            );
        }
    }
}
