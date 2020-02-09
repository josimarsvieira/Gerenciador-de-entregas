using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class InclusaoDeClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coleta",
                columns: table => new
                {
                    ColetaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeCliente = table.Column<string>(nullable: false),
                    Solicitante = table.Column<string>(nullable: false),
                    Volumes = table.Column<int>(nullable: false),
                    Metragem = table.Column<double>(nullable: false),
                    Peso = table.Column<double>(nullable: false),
                    DataColeta = table.Column<DateTime>(nullable: false),
                    DataSolicitacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coleta", x => x.ColetaId);
                });

            migrationBuilder.CreateTable(
                name: "EntregaUrgente",
                columns: table => new
                {
                    EntregaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cliente = table.Column<string>(nullable: false),
                    Nota = table.Column<int>(nullable: false),
                    Solicitante = table.Column<string>(nullable: false),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    Urgente = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregaUrgente", x => x.EntregaId);
                });

            migrationBuilder.CreateTable(
                name: "Falta",
                columns: table => new
                {
                    FaltaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Remetente = table.Column<string>(nullable: true),
                    Destinatario = table.Column<string>(nullable: true),
                    NumeroNota = table.Column<int>(nullable: false),
                    NumeroCTE = table.Column<int>(nullable: false),
                    VolumesFaltante = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Falta", x => x.FaltaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coleta");

            migrationBuilder.DropTable(
                name: "EntregaUrgente");

            migrationBuilder.DropTable(
                name: "Falta");
        }
    }
}