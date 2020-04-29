using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LivraisonPointRelais.Model.Migrations
{
    public partial class SeedDataUpdate_2020_04_29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "ClientId", "Nom", "NumeroCommande", "SiteMarchandise" },
                values: new object[] { new Guid("09cda71a-6d75-4b6d-84b4-b0366ac40499"), new Guid("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"), "Tesla Model S", "4U7ML8F", "AbDiscount.com" });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "ClientId", "Nom", "NumeroCommande", "SiteMarchandise" },
                values: new object[] { new Guid("eced6ac7-1fe2-4c5c-9ef3-e5d42e43ac50"), new Guid("cec5d75e-0b5c-400b-a892-5f0cce618ee9"), "Apple Iphone 3S", "GG7ML8F", "AbDiscount.com" });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "ClientId", "Nom", "NumeroCommande", "SiteMarchandise" },
                values: new object[] { new Guid("d9ca1214-6b4c-4e42-94ea-7ff9bb042997"), new Guid("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"), "Apple Watch 5", "GG7MLHF", "AbDiscount.com" });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "ClientId", "Nom", "NumeroCommande", "SiteMarchandise" },
                values: new object[] { new Guid("2bcc2d4a-6c4b-44c7-8847-861cdf59e0fe"), new Guid("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"), "Polo Slim XL", "GGIJUHY", "BestBuy.eu" });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "ClientId", "Nom", "NumeroCommande", "SiteMarchandise" },
                values: new object[] { new Guid("0669081c-df18-4510-9c95-614c4a4d91b4"), new Guid("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"), "Sac Montblanc", "IIKJUHY", "BestBuy.eu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: new Guid("0669081c-df18-4510-9c95-614c4a4d91b4"));

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: new Guid("09cda71a-6d75-4b6d-84b4-b0366ac40499"));

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: new Guid("2bcc2d4a-6c4b-44c7-8847-861cdf59e0fe"));

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: new Guid("d9ca1214-6b4c-4e42-94ea-7ff9bb042997"));

            migrationBuilder.DeleteData(
                table: "Produits",
                keyColumn: "Id",
                keyValue: new Guid("eced6ac7-1fe2-4c5c-9ef3-e5d42e43ac50"));
        }
    }
}
