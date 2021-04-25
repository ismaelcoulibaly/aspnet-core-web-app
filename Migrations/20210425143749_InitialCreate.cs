using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bibliotheque.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livre",
                columns: table => new
                {
                    idLivre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomLivre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    langue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isbn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    auteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    annee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livre", x => x.idLivre);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livre");
        }
    }
}
