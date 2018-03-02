using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyStoreFront1.Migrations
{
    public partial class March1Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsGenres");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenresId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_GenresId",
                table: "Products",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Genres_GenresId",
                table: "Products",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Genres_GenresId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_GenresId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GenresId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductsGenres",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    GenreID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsGenres", x => new { x.ProductID, x.GenreID });
                    table.ForeignKey(
                        name: "FK_ProductsGenres_Genres",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductsGenres_Products",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGenres_GenreID",
                table: "ProductsGenres",
                column: "GenreID");
        }
    }
}
