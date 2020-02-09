using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class Rebuild2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_EntregaUrgente_EntregaId",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_EntregaId",
                table: "Nota");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f82536f8-32e6-4ca5-aa41-7ae0c6420ee7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd589a79-768a-495f-8d36-53336a2e6a5e");

            migrationBuilder.DropColumn(
                name: "EntregaId",
                table: "Nota");

            migrationBuilder.AddColumn<int>(
                name: "EntregaFaltaId",
                table: "Nota",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Falta_EntregaFaltaId",
                table: "Nota",
                column: "EntregaFaltaId",
                principalTable: "Falta",
                principalColumn: "FaltaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Falta_EntregaFaltaId",
                table: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_Nota_EntregaFaltaId",
                table: "Nota");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "114d245d-0d34-462e-80c5-0424be1d3cae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d48738f6-f366-4555-a4a4-13cbcec0bf96");

            migrationBuilder.DropColumn(
                name: "EntregaFaltaId",
                table: "Nota");

            migrationBuilder.AddColumn<int>(
                name: "EntregaId",
                table: "Nota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd589a79-768a-495f-8d36-53336a2e6a5e", "0e91fd05-274c-4e8e-aa1e-6189de55ac24", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f82536f8-32e6-4ca5-aa41-7ae0c6420ee7", "33d91cf1-571f-49a1-92ee-187a056283e1", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Nota_EntregaId",
                table: "Nota",
                column: "EntregaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_EntregaUrgente_EntregaId",
                table: "Nota",
                column: "EntregaId",
                principalTable: "EntregaUrgente",
                principalColumn: "EntregaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}