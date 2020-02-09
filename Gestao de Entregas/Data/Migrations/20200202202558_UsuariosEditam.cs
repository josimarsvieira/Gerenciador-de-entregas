using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class UsuariosEditam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23eeeb69-4aae-4017-a6ed-412bd5e933b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40e20e85-027f-4030-b6fc-ad82f253eaf4");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEntregueId",
                table: "EntregaUrgente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioUrgenteId",
                table: "EntregaUrgente",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e830090f-48e9-435f-8d11-9fec31f93358", "11a00543-431a-455a-9e89-603b85e7f474", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfcedb19-efdc-4420-aab5-0149eb034373", "1917be6f-5b94-46c5-b15b-224435d547ac", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_EntregaUrgente_UsuarioEntregueId",
                table: "EntregaUrgente",
                column: "UsuarioEntregueId");

            migrationBuilder.CreateIndex(
                name: "IX_EntregaUrgente_UsuarioUrgenteId",
                table: "EntregaUrgente",
                column: "UsuarioUrgenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioEntregueId",
                table: "EntregaUrgente",
                column: "UsuarioEntregueId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioEntregueId",
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

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfcedb19-efdc-4420-aab5-0149eb034373");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e830090f-48e9-435f-8d11-9fec31f93358");

            migrationBuilder.DropColumn(
                name: "UsuarioEntregueId",
                table: "EntregaUrgente");

            migrationBuilder.DropColumn(
                name: "UsuarioUrgenteId",
                table: "EntregaUrgente");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23eeeb69-4aae-4017-a6ed-412bd5e933b5", "a24cbf7a-0bed-4a45-8f4c-c87079a313ce", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "40e20e85-027f-4030-b6fc-ad82f253eaf4", "28d0e1eb-af67-4d5b-8a5f-e7bbac778b2a", "Admin", "ADMIN" });
        }
    }
}