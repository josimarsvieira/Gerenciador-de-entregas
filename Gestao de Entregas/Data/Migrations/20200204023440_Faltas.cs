using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class Faltas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Falta");

            migrationBuilder.AlterColumn<string>(
                name: "Remetente",
                table: "Falta",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Destinatario",
                table: "Falta",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFalta",
                table: "Falta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Encontrado",
                table: "Falta",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Falta",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FaltaStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FaltaId = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: false),
                    DataStatus = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaltaStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaltaStatus_Falta_FaltaId",
                        column: x => x.FaltaId,
                        principalTable: "Falta",
                        principalColumn: "FaltaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaltaStatus_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Falta_UsuarioId",
                table: "Falta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FaltaStatus_FaltaId",
                table: "FaltaStatus",
                column: "FaltaId");

            migrationBuilder.CreateIndex(
                name: "IX_FaltaStatus_UsuarioId",
                table: "FaltaStatus",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Falta_AspNetUsers_UsuarioId",
                table: "Falta",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Falta_AspNetUsers_UsuarioId",
                table: "Falta");

            migrationBuilder.DropTable(
                name: "FaltaStatus");

            migrationBuilder.DropIndex(
                name: "IX_Falta_UsuarioId",
                table: "Falta");

            migrationBuilder.DropColumn(
                name: "DataFalta",
                table: "Falta");

            migrationBuilder.DropColumn(
                name: "Encontrado",
                table: "Falta");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Falta");

            migrationBuilder.AlterColumn<string>(
                name: "Remetente",
                table: "Falta",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Destinatario",
                table: "Falta",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Falta",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}