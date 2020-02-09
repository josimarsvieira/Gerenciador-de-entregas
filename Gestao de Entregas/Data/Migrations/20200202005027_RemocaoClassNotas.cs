using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class RemocaoClassNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Destinario",
                table: "EntregaUrgente");

            migrationBuilder.AddColumn<string>(
                name: "Destinatario",
                table: "EntregaUrgente",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "EntregaUrgente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23eeeb69-4aae-4017-a6ed-412bd5e933b5", "a24cbf7a-0bed-4a45-8f4c-c87079a313ce", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "40e20e85-027f-4030-b6fc-ad82f253eaf4", "28d0e1eb-af67-4d5b-8a5f-e7bbac778b2a", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23eeeb69-4aae-4017-a6ed-412bd5e933b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40e20e85-027f-4030-b6fc-ad82f253eaf4");

            migrationBuilder.DropColumn(
                name: "Destinatario",
                table: "EntregaUrgente");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "EntregaUrgente");

            migrationBuilder.AddColumn<string>(
                name: "Destinario",
                table: "EntregaUrgente",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntregaId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
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
    }
}