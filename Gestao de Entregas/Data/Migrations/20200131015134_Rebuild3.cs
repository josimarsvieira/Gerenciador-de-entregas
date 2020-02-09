using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class Rebuild3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "114d245d-0d34-462e-80c5-0424be1d3cae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d48738f6-f366-4555-a4a4-13cbcec0bf96");

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false),
                    EntregaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotaFiscal_EntregaUrgente_EntregaId",
                        column: x => x.EntregaId,
                        principalTable: "EntregaUrgente",
                        principalColumn: "EntregaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4bc0520-9f53-490d-9efa-9f2b227462e7", "10844d9f-8485-41eb-a0d1-e95221859183", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18d298bd-8389-4a7a-897e-9ba7ff72efd0", "88be5939-4d2c-4563-b47f-395d60e6ae5c", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_EntregaId",
                table: "NotaFiscal",
                column: "EntregaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18d298bd-8389-4a7a-897e-9ba7ff72efd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4bc0520-9f53-490d-9efa-9f2b227462e7");

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntregaFaltaId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nota_Falta_EntregaFaltaId",
                        column: x => x.EntregaFaltaId,
                        principalTable: "Falta",
                        principalColumn: "FaltaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "114d245d-0d34-462e-80c5-0424be1d3cae", "e48f62ea-51d7-4635-be30-cdedece438e6", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d48738f6-f366-4555-a4a4-13cbcec0bf96", "dac30845-5ef8-4259-b83c-921e94b67c60", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Nota_EntregaFaltaId",
                table: "Nota",
                column: "EntregaFaltaId");
        }
    }
}