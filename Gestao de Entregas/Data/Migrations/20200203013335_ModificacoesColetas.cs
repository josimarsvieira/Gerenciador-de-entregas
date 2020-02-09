using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class ModificacoesColetas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfcedb19-efdc-4420-aab5-0149eb034373");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e830090f-48e9-435f-8d11-9fec31f93358");

            migrationBuilder.AddColumn<bool>(
                name: "Cancelado",
                table: "Coleta",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Coletado",
                table: "Coleta",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Coleta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCanceladoId",
                table: "Coleta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioColetadoId",
                table: "Coleta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Coleta",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "511a235a-338b-4b6e-a14c-423303a7f6a3", "652be30b-2bc4-42ab-a9dc-5dcb88f7d818", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19cfe7ed-e1a0-42dc-909a-1ac44c643006", "a257ecdc-6d67-4665-b4cf-e32e5694fca4", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_UsuarioCanceladoId",
                table: "Coleta",
                column: "UsuarioCanceladoId");

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_UsuarioColetadoId",
                table: "Coleta",
                column: "UsuarioColetadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Coleta_UsuarioId",
                table: "Coleta",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coleta_AspNetUsers_UsuarioCanceladoId",
                table: "Coleta",
                column: "UsuarioCanceladoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coleta_AspNetUsers_UsuarioColetadoId",
                table: "Coleta",
                column: "UsuarioColetadoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coleta_AspNetUsers_UsuarioId",
                table: "Coleta",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coleta_AspNetUsers_UsuarioCanceladoId",
                table: "Coleta");

            migrationBuilder.DropForeignKey(
                name: "FK_Coleta_AspNetUsers_UsuarioColetadoId",
                table: "Coleta");

            migrationBuilder.DropForeignKey(
                name: "FK_Coleta_AspNetUsers_UsuarioId",
                table: "Coleta");

            migrationBuilder.DropIndex(
                name: "IX_Coleta_UsuarioCanceladoId",
                table: "Coleta");

            migrationBuilder.DropIndex(
                name: "IX_Coleta_UsuarioColetadoId",
                table: "Coleta");

            migrationBuilder.DropIndex(
                name: "IX_Coleta_UsuarioId",
                table: "Coleta");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19cfe7ed-e1a0-42dc-909a-1ac44c643006");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "511a235a-338b-4b6e-a14c-423303a7f6a3");

            migrationBuilder.DropColumn(
                name: "Cancelado",
                table: "Coleta");

            migrationBuilder.DropColumn(
                name: "Coletado",
                table: "Coleta");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Coleta");

            migrationBuilder.DropColumn(
                name: "UsuarioCanceladoId",
                table: "Coleta");

            migrationBuilder.DropColumn(
                name: "UsuarioColetadoId",
                table: "Coleta");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Coleta");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e830090f-48e9-435f-8d11-9fec31f93358", "11a00543-431a-455a-9e89-603b85e7f474", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfcedb19-efdc-4420-aab5-0149eb034373", "1917be6f-5b94-46c5-b15b-224435d547ac", "Admin", "ADMIN" });
        }
    }
}