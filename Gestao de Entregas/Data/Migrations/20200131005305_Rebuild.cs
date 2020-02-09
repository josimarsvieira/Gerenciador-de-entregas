using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class Rebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03627fda-a4cb-4282-8515-89550bedad95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de0248f8-71fa-4dff-996d-7dbb2ef4e98c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd589a79-768a-495f-8d36-53336a2e6a5e", "0e91fd05-274c-4e8e-aa1e-6189de55ac24", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f82536f8-32e6-4ca5-aa41-7ae0c6420ee7", "33d91cf1-571f-49a1-92ee-187a056283e1", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f82536f8-32e6-4ca5-aa41-7ae0c6420ee7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd589a79-768a-495f-8d36-53336a2e6a5e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03627fda-a4cb-4282-8515-89550bedad95", "386a34e6-e770-46f8-87e3-857fc8830b21", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de0248f8-71fa-4dff-996d-7dbb2ef4e98c", "c8ae3a0d-1a34-421e-bcc7-3b73150ff5bc", "Admin", "ADMIN" });
        }
    }
}