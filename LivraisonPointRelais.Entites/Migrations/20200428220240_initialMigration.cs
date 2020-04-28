using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LivraisonPointRelais.Model.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    Prenom = table.Column<string>(nullable: false),
                    Sexe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointsRelais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdPointRelais = table.Column<string>(maxLength: 10, nullable: false),
                    LibelleCommercial = table.Column<string>(nullable: false),
                    Gestionnaire = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsRelais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NumeroCommande = table.Column<string>(maxLength: 8, nullable: false),
                    SiteMarchandise = table.Column<string>(nullable: false),
                    Nom = table.Column<string>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produits_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Livraisons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IdProduit = table.Column<Guid>(nullable: false),
                    IdPointRelais = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livraisons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livraisons_PointsRelais_IdPointRelais",
                        column: x => x.IdPointRelais,
                        principalTable: "PointsRelais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livraisons_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Nom", "Prenom", "Sexe" },
                values: new object[] { new Guid("cec5d75e-0b5c-400b-a892-5f0cce618ee8"), "Cruiz", "Tom", 0 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Nom", "Prenom", "Sexe" },
                values: new object[] { new Guid("cec5d75e-0b5c-400b-a892-5f0cce618ee9"), "Kidman", "Nicole", 1 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Nom", "Prenom", "Sexe" },
                values: new object[] { new Guid("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"), "Brad", "Pit", 0 });

            migrationBuilder.InsertData(
                table: "PointsRelais",
                columns: new[] { "Id", "Gestionnaire", "IdPointRelais", "LibelleCommercial" },
                values: new object[] { new Guid("a9731552-6219-47ae-99b1-d574bcbc399d"), "JEROME", "11111111", "Top Shop" });

            migrationBuilder.InsertData(
                table: "PointsRelais",
                columns: new[] { "Id", "Gestionnaire", "IdPointRelais", "LibelleCommercial" },
                values: new object[] { new Guid("a8d28d5f-8a98-423f-a4a0-6232db993b24"), "CELINE", "2222222", "Wonderful Prix" });

            migrationBuilder.InsertData(
                table: "PointsRelais",
                columns: new[] { "Id", "Gestionnaire", "IdPointRelais", "LibelleCommercial" },
                values: new object[] { new Guid("7b476381-8356-4c38-999f-d442ed944b50"), "TIMOTHEE", "33333333", "Good Phone" });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "ClientId", "Nom", "NumeroCommande", "SiteMarchandise" },
                values: new object[] { new Guid("ec38084f-7c33-4a96-84f2-91939c0fe819"), new Guid("cec5d75e-0b5c-400b-a892-5f0cce618ee8"), "IRobot Model S", "4H7JK8F", "AbDiscount.com" });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "ClientId", "Nom", "NumeroCommande", "SiteMarchandise" },
                values: new object[] { new Guid("02d686c5-dc32-4bc2-950e-32ecfd41fe9d"), new Guid("cec5d75e-0b5c-400b-a892-5f0cce618ee9"), "Drone enfant 4 hélices", "4H0AK8F", "Amazonia.fr" });

            migrationBuilder.InsertData(
                table: "Produits",
                columns: new[] { "Id", "ClientId", "Nom", "NumeroCommande", "SiteMarchandise" },
                values: new object[] { new Guid("91a0fb8a-e7bf-432c-bd34-e197f858ad6e"), new Guid("0ee2bf8c-2d6e-43f3-aa03-568a418b580f"), "Canapé Angle", "4U7JK8F", "BestBuy.eu" });

            migrationBuilder.InsertData(
                table: "Livraisons",
                columns: new[] { "Id", "Date", "IdPointRelais", "IdProduit" },
                values: new object[] { new Guid("c613c52f-a8c9-47b1-99d5-ce0e75e0de30"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a9731552-6219-47ae-99b1-d574bcbc399d"), new Guid("ec38084f-7c33-4a96-84f2-91939c0fe819") });

            migrationBuilder.InsertData(
                table: "Livraisons",
                columns: new[] { "Id", "Date", "IdPointRelais", "IdProduit" },
                values: new object[] { new Guid("f23ce297-5baf-47a9-947b-417bbf80db13"), new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a8d28d5f-8a98-423f-a4a0-6232db993b24"), new Guid("02d686c5-dc32-4bc2-950e-32ecfd41fe9d") });

            migrationBuilder.InsertData(
                table: "Livraisons",
                columns: new[] { "Id", "Date", "IdPointRelais", "IdProduit" },
                values: new object[] { new Guid("98932b8f-572e-4390-87c2-c59c8c836b67"), new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7b476381-8356-4c38-999f-d442ed944b50"), new Guid("91a0fb8a-e7bf-432c-bd34-e197f858ad6e") });

            migrationBuilder.CreateIndex(
                name: "IX_Livraisons_IdPointRelais",
                table: "Livraisons",
                column: "IdPointRelais");

            migrationBuilder.CreateIndex(
                name: "IX_Livraisons_IdProduit",
                table: "Livraisons",
                column: "IdProduit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produits_ClientId",
                table: "Produits",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livraisons");

            migrationBuilder.DropTable(
                name: "PointsRelais");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
