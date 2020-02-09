using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class AdicionaUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c976428-83dd-4f09-b014-b0fa51a3b383");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3ea3c19-f0f4-4b1f-92f9-70399f0df2ec");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "EntregaUrgente",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d2bc1bf-498f-402e-9226-e3e66b8994cb", "9419bbeb-b1d3-4fd9-bff4-28a012e2de61", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0613706d-d4b7-4f24-8b59-e2eff87a378e", "d34f24a3-b456-48e4-9918-da1699caf27f", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_EntregaUrgente_UsuarioId",
                table: "EntregaUrgente",
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

            migrationBuilder.DropIndex(
                name: "IX_EntregaUrgente_UsuarioId",
                table: "EntregaUrgente");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0613706d-d4b7-4f24-8b59-e2eff87a378e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d2bc1bf-498f-402e-9226-e3e66b8994cb");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "EntregaUrgente");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3ea3c19-f0f4-4b1f-92f9-70399f0df2ec", "9a631011-10ad-4cb5-8e7d-a020f8f74668", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c976428-83dd-4f09-b014-b0fa51a3b383", "d6edadbb-869e-412e-9ae2-8ffc306b7674", "Admin", "ADMIN" });
        }
    }
}