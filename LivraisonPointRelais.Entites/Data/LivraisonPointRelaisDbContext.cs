using System;
using LivraisonPointRelais.Model.Entites;
using LivraisonPointRelais.Model.Entites.Reference;
using Microsoft.EntityFrameworkCore;

namespace LivraisonPointRelais.Model.Data
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
                    Nom = "Canapé Angle"
                },
                new Produit
                {
                    Id = Guid.Parse("09cda71a-6d75-4b6d-84b4-b0366ac40499"),
                    ClientId = Guid.Parse("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"),
                    NumeroCommande = "4U7ML8F",
                    SiteMarchandise = "AbDiscount.com",
                    Nom = "Tesla Model S"
                },
                new Produit
                {
                    Id = Guid.Parse("eced6ac7-1fe2-4c5c-9ef3-e5d42e43ac50"),
                    ClientId = Guid.Parse("cec5d75e-0b5c-400b-a892-5f0cce618ee9"),
                    NumeroCommande = "GG7ML8F",
                    SiteMarchandise = "AbDiscount.com",
                    Nom = "Apple Iphone 3S"
                },
                new Produit
                {
                    Id = Guid.Parse("d9ca1214-6b4c-4e42-94ea-7ff9bb042997"),
                    ClientId = Guid.Parse("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"),
                    NumeroCommande = "GG7MLHF",
                    SiteMarchandise = "AbDiscount.com",
                    Nom = "Apple Watch 5"
                },
                new Produit
                {
                    Id = Guid.Parse("2bcc2d4a-6c4b-44c7-8847-861cdf59e0fe"),
                    ClientId = Guid.Parse("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"),
                    NumeroCommande = "GGIJUHY",
                    SiteMarchandise = "BestBuy.eu",
                    Nom = "Polo Slim XL"
                },
                new Produit
                {
                    Id = Guid.Parse("0669081c-df18-4510-9c95-614c4a4d91b4"),
                    ClientId = Guid.Parse("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"),
                    NumeroCommande = "IIKJUHY",
                    SiteMarchandise = "BestBuy.eu",
                    Nom = "Sac Montblanc"
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
                    IdPointRelais = Guid.Parse("a9731552-6219-47ae-99b1-d574bcbc399d")
                },
                new Livraison
                {
                    Id = Guid.Parse("f23ce297-5baf-47a9-947b-417bbf80db13"),
                    Date = new DateTime(2020, 1, 3),
                    IdProduit = Guid.Parse("02d686c5-dc32-4bc2-950e-32ecfd41fe9d"),
                    IdPointRelais = Guid.Parse("a8d28d5f-8a98-423f-a4a0-6232db993b24")
                },
                new Livraison
                {
                    Id = Guid.Parse("98932b8f-572e-4390-87c2-c59c8c836b67"),
                    Date = new DateTime(2019, 10, 15),
                    IdProduit = Guid.Parse("91a0fb8a-e7bf-432c-bd34-e197f858ad6e"),
                    IdPointRelais = Guid.Parse("7b476381-8356-4c38-999f-d442ed944b50")
                }
            );
        }
    }
}
