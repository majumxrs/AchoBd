﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acho.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "AnimalStatus",
                table: "Animais",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalStatus",
                table: "Animais");
        }
    }
}
