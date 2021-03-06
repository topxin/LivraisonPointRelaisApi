﻿// <auto-generated />
using System;
using LivraisonPointRelais.Model.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LivraisonPointRelais.Model.Migrations
{
    [DbContext(typeof(LivraisonPointRelaisDbContext))]
    [Migration("20200428220240_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("HistoriqueAffectation.Model.Entites.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Sexe")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cec5d75e-0b5c-400b-a892-5f0cce618ee8"),
                            Nom = "Cruiz",
                            Prenom = "Tom",
                            Sexe = 0
                        },
                        new
                        {
                            Id = new Guid("cec5d75e-0b5c-400b-a892-5f0cce618ee9"),
                            Nom = "Kidman",
                            Prenom = "Nicole",
                            Sexe = 1
                        },
                        new
                        {
                            Id = new Guid("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"),
                            Nom = "Brad",
                            Prenom = "Pit",
                            Sexe = 0
                        });
                });

            modelBuilder.Entity("HistoriqueAffectation.Model.Entites.Livraison", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdPointRelais")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdProduit")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdPointRelais");

                    b.HasIndex("IdProduit")
                        .IsUnique();

                    b.ToTable("Livraisons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c613c52f-a8c9-47b1-99d5-ce0e75e0de30"),
                            Date = new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPointRelais = new Guid("a9731552-6219-47ae-99b1-d574bcbc399d"),
                            IdProduit = new Guid("ec38084f-7c33-4a96-84f2-91939c0fe819")
                        },
                        new
                        {
                            Id = new Guid("f23ce297-5baf-47a9-947b-417bbf80db13"),
                            Date = new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPointRelais = new Guid("a8d28d5f-8a98-423f-a4a0-6232db993b24"),
                            IdProduit = new Guid("02d686c5-dc32-4bc2-950e-32ecfd41fe9d")
                        },
                        new
                        {
                            Id = new Guid("98932b8f-572e-4390-87c2-c59c8c836b67"),
                            Date = new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdPointRelais = new Guid("7b476381-8356-4c38-999f-d442ed944b50"),
                            IdProduit = new Guid("91a0fb8a-e7bf-432c-bd34-e197f858ad6e")
                        });
                });

            modelBuilder.Entity("HistoriqueAffectation.Model.Entites.PointRelais", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gestionnaire")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdPointRelais")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.Property<string>("LibelleCommercial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PointsRelais");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a9731552-6219-47ae-99b1-d574bcbc399d"),
                            Gestionnaire = "JEROME",
                            IdPointRelais = "11111111",
                            LibelleCommercial = "Top Shop"
                        },
                        new
                        {
                            Id = new Guid("a8d28d5f-8a98-423f-a4a0-6232db993b24"),
                            Gestionnaire = "CELINE",
                            IdPointRelais = "2222222",
                            LibelleCommercial = "Wonderful Prix"
                        },
                        new
                        {
                            Id = new Guid("7b476381-8356-4c38-999f-d442ed944b50"),
                            Gestionnaire = "TIMOTHEE",
                            IdPointRelais = "33333333",
                            LibelleCommercial = "Good Phone"
                        });
                });

            modelBuilder.Entity("HistoriqueAffectation.Model.Entites.Produit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroCommande")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(8);

                    b.Property<string>("SiteMarchandise")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Produits");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ec38084f-7c33-4a96-84f2-91939c0fe819"),
                            ClientId = new Guid("cec5d75e-0b5c-400b-a892-5f0cce618ee8"),
                            Nom = "IRobot Model S",
                            NumeroCommande = "4H7JK8F",
                            SiteMarchandise = "AbDiscount.com"
                        },
                        new
                        {
                            Id = new Guid("02d686c5-dc32-4bc2-950e-32ecfd41fe9d"),
                            ClientId = new Guid("cec5d75e-0b5c-400b-a892-5f0cce618ee9"),
                            Nom = "Drone enfant 4 hélices",
                            NumeroCommande = "4H0AK8F",
                            SiteMarchandise = "Amazonia.fr"
                        },
                        new
                        {
                            Id = new Guid("91a0fb8a-e7bf-432c-bd34-e197f858ad6e"),
                            ClientId = new Guid("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"),
                            Nom = "Canapé Angle",
                            NumeroCommande = "4U7JK8F",
                            SiteMarchandise = "BestBuy.eu"
                        });
                });

            modelBuilder.Entity("HistoriqueAffectation.Model.Entites.Livraison", b =>
                {
                    b.HasOne("HistoriqueAffectation.Model.Entites.PointRelais", "PointRelais")
                        .WithMany("Livraisons")
                        .HasForeignKey("IdPointRelais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HistoriqueAffectation.Model.Entites.Produit", "Produit")
                        .WithOne("Livraison")
                        .HasForeignKey("HistoriqueAffectation.Model.Entites.Livraison", "IdProduit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HistoriqueAffectation.Model.Entites.Produit", b =>
                {
                    b.HasOne("HistoriqueAffectation.Model.Entites.Client", "Client")
                        .WithMany("produits")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
