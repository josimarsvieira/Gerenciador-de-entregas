using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60f51eec-af95-4f3d-ada6-0c54aac75ca8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7432598-c03b-440c-a0d4-1ce583bc6740");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03627fda-a4cb-4282-8515-89550bedad95", "386a34e6-e770-46f8-87e3-857fc8830b21", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de0248f8-71fa-4dff-996d-7dbb2ef4e98c", "c8ae3a0d-1a34-421e-bcc7-3b73150ff5bc", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "60f51eec-af95-4f3d-ada6-0c54aac75ca8", "0bdce872-19c2-4a54-9c4e-3e84b141977f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7432598-c03b-440c-a0d4-1ce583bc6740", "3319f752-85ee-447f-aa78-3f540a395612", "Admin", "ADMIN" });
        }
    }
}