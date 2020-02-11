using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class campoRetiranaEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Retira",
                table: "EntregaUrgente",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd363aee-4900-4952-8461-d1ef75207373", "943625f6-8a41-4769-a93a-e6bd574fca3c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4d0d3ed-f8ff-4679-a20b-ca2009b52d1c", "bb0869eb-e324-4e82-8730-70eea2d9e389", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d0d3ed-f8ff-4679-a20b-ca2009b52d1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd363aee-4900-4952-8461-d1ef75207373");

            migrationBuilder.DropColumn(
                name: "Retira",
                table: "EntregaUrgente");
        }
    }
}
