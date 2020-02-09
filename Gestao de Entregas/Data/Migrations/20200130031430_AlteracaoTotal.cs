using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class AlteracaoTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioId",
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
                name: "Cliente",
                table: "EntregaUrgente");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "EntregaUrgente");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "EntregaUrgente",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Solicitante",
                table: "EntregaUrgente",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Destinario",
                table: "EntregaUrgente",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "Entregue",
                table: "EntregaUrgente",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NotasId",
                table: "EntregaUrgente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "EntregaUrgente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remetente",
                table: "EntregaUrgente",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5eab2842-aad4-487b-9e14-72cef87fd35f", "e2fbfa44-8e13-403e-8a77-8071e63664ea", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a289a62b-59e7-45df-904a-b5675e4ef727", "0375088e-6b73-458f-8f31-a00688b6a937", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_EntregaUrgente_NotasId",
                table: "EntregaUrgente",
                column: "NotasId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaUrgente_Nota_NotasId",
                table: "EntregaUrgente",
                column: "NotasId",
                principalTable: "Nota",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioId",
                table: "EntregaUrgente",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntregaUrgente_Nota_NotasId",
                table: "EntregaUrgente");

            migrationBuilder.DropForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioId",
                table: "EntregaUrgente");

            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropIndex(
                name: "IX_EntregaUrgente_NotasId",
                table: "EntregaUrgente");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5eab2842-aad4-487b-9e14-72cef87fd35f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a289a62b-59e7-45df-904a-b5675e4ef727");

            migrationBuilder.DropColumn(
                name: "Destinario",
                table: "EntregaUrgente");

            migrationBuilder.DropColumn(
                name: "Entregue",
                table: "EntregaUrgente");

            migrationBuilder.DropColumn(
                name: "NotasId",
                table: "EntregaUrgente");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "EntregaUrgente");

            migrationBuilder.DropColumn(
                name: "Remetente",
                table: "EntregaUrgente");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "EntregaUrgente",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Solicitante",
                table: "EntregaUrgente",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "EntregaUrgente",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "EntregaUrgente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d2bc1bf-498f-402e-9226-e3e66b8994cb", "9419bbeb-b1d3-4fd9-bff4-28a012e2de61", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0613706d-d4b7-4f24-8b59-e2eff87a378e", "d34f24a3-b456-48e4-9918-da1699caf27f", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_EntregaUrgente_AspNetUsers_UsuarioId",
                table: "EntregaUrgente",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}