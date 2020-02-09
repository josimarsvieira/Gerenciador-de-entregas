using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3ea3c19-f0f4-4b1f-92f9-70399f0df2ec", "9a631011-10ad-4cb5-8e7d-a020f8f74668", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c976428-83dd-4f09-b014-b0fa51a3b383", "d6edadbb-869e-412e-9ae2-8ffc306b7674", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c976428-83dd-4f09-b014-b0fa51a3b383");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3ea3c19-f0f4-4b1f-92f9-70399f0df2ec");
        }
    }
}