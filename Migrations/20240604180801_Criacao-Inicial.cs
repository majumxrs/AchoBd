using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acho.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioSenha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    AnimaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalRaca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalCor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalSexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalObservacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalDataDesaparecimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalDataEncontro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.AnimaisId);
                    table.ForeignKey(
                        name: "FK_Animais_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Observacoes",
                columns: table => new
                {
                    ObservacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObservacaoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservacaoLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObservacaoData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimaisId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacoes", x => x.ObservacaoId);
                    table.ForeignKey(
                        name: "FK_Observacoes_Animais_AnimaisId",
                        column: x => x.AnimaisId,
                        principalTable: "Animais",
                        principalColumn: "AnimaisId");
                    table.ForeignKey(
                        name: "FK_Observacoes_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animais_usuarioId",
                table: "Animais",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacoes_AnimaisId",
                table: "Observacoes",
                column: "AnimaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Observacoes_UsuarioId",
                table: "Observacoes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Observacoes");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
