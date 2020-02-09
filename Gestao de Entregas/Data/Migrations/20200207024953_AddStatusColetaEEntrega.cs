using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class AddStatusColetaEEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coleta_AspNetUsers_UsuarioCanceladoId",
                table: "Coleta");

            migrationBuilder.DropForeignKey(
                name: "FK_Coleta_AspNetUsers_UsuarioColetadoId",
                table: "Coleta");

            migrationBuilder.DropForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioEntregueId",
                table: "EntregaUrgente");

            migrationBuilder.DropForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioId",
                table: "EntregaUrgente");

            migrationBuilder.DropForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioUrgenteId",
                table: "EntregaUrgente");

            migrationBuilder.DropIndex(
                name: "IX_EntregaUrgente_UsuarioEntregueId",
                table: "EntregaUrgente");

            migrationBuilder.DropIndex(
                name: "IX_EntregaUrgente_UsuarioUrgenteId",
                table: "EntregaUrgente");

            migrationBuilder.DropIndex(
                name: "IX_Coleta_UsuarioCanceladoId",
                table: "Coleta");

            migrationBuilder.DropIndex(
                name: "IX_Coleta_UsuarioColetadoId",
                table: "Coleta");

            migrationBuilder.DropColumn(
                name: "UsuarioEntregueId",
                table: "EntregaUrgente");

            migrationBuilder.DropColumn(
                name: "UsuarioUrgenteId",
                table: "EntregaUrgente");

            migrationBuilder.DropColumn(
                name: "UsuarioCanceladoId",
                table: "Coleta");

            migrationBuilder.DropColumn(
                name: "UsuarioColetadoId",
                table: "Coleta");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "EntregaUrgente",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Solicitante",
                table: "EntregaUrgente",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ColetaStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ColetaId = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: false),
                    DataStatus = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColetaStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColetaStatus_Coleta_ColetaId",
                        column: x => x.ColetaId,
                        principalTable: "Coleta",
                        principalColumn: "ColetaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColetaStatus_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntregaUrgenteStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntregaUrgenteEntregaId = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: false),
                    DataStatus = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregaUrgenteStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntregaUrgenteStatus_EntregaUrgente_EntregaUrgenteEntregaId",
                        column: x => x.EntregaUrgenteEntregaId,
                        principalTable: "EntregaUrgente",
                        principalColumn: "EntregaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntregaUrgenteStatus_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColetaStatus_ColetaId",
                table: "ColetaStatus",
                column: "ColetaId");

            migrationBuilder.CreateIndex(
                name: "IX_ColetaStatus_UsuarioId",
                table: "ColetaStatus",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EntregaUrgenteStatus_EntregaUrgenteEntregaId",
                table: "EntregaUrgenteStatus",
                column: "EntregaUrgenteEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntregaUrgenteStatus_UsuarioId",
                table: "EntregaUrgenteStatus",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioId",
                table: "EntregaUrgente",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioId",
                table: "EntregaUrgente");

            migrationBuilder.DropTable(
                name: "ColetaStatus");

            migrationBuilder.DropTable(
                name: "EntregaUrgenteStatus");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "EntregaUrgente",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Solicitante",
                table: "EntregaUrgente",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEntregueId",
                table: "EntregaUrgente",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUrgenteId",
                table: "EntregaUrgente",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCanceladoId",
                table: "Coleta",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioColetadoId",
                table: "Coleta",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntregaUrgente_UsuarioEntregueId",
                table: "EntregaUrgente",
                column: "UsuarioEntregueId");

            migrationBuilder.CreateIndex(
                name: "IX_EntregaUrgente_UsuarioUrgenteId",
                table: "EntregaUrgente",
                column: "UsuarioUrgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_UsuarioCanceladoId",
                table: "Coleta",
                column: "UsuarioCanceladoId");

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_UsuarioColetadoId",
                table: "Coleta",
                column: "UsuarioColetadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coleta_AspNetUsers_UsuarioCanceladoId",
                table: "Coleta",
                column: "UsuarioCanceladoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coleta_AspNetUsers_UsuarioColetadoId",
                table: "Coleta",
                column: "UsuarioColetadoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioEntregueId",
                table: "EntregaUrgente",
                column: "UsuarioEntregueId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioId",
                table: "EntregaUrgente",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioUrgenteId",
                table: "EntregaUrgente",
                column: "UsuarioUrgenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
