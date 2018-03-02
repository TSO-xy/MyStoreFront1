using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyStoreFront1.Migrations
{
    public partial class March1Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Genres_GenresId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "Products",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_GenresId",
                table: "Products",
                newName: "IX_Products_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Genres_GenreId",
                table: "Products",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Genres_GenreId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Products",
                newName: "GenresId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_GenreId",
                table: "Products",
                newName: "IX_Products_GenresId");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Products",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Genres_GenresId",
                table: "Products",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
