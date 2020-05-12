using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Gestao_de_Entregas.Data.Migrations
{
    public partial class atualizacaodeBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d0d3ed-f8ff-4679-a20b-ca2009b52d1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd363aee-4900-4952-8461-d1ef75207373");

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Funcao = table.Column<string>(nullable: true),
                    HoraIncio = table.Column<TimeSpan>(nullable: false),
                    HoraTermino = table.Column<TimeSpan>(nullable: false),
                    HoraAlmocoSaida = table.Column<TimeSpan>(nullable: false),
                    HoraAlmocoRetorno = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BancoDeHoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HorasExtras = table.Column<TimeSpan>(nullable: false),
                    Justificativa = table.Column<string>(nullable: true),
                    FuncionarioId = table.Column<int>(nullable: true),
                    DataRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BancoDeHoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BancoDeHoras_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorasFuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Entrada = table.Column<TimeSpan>(nullable: false),
                    Saida = table.Column<TimeSpan>(nullable: false),
                    AlmocoSaida = table.Column<TimeSpan>(nullable: false),
                    AlmocoRetorno = table.Column<TimeSpan>(nullable: false),
                    Extras = table.Column<TimeSpan>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: true),
                    DataRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasFuncionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorasFuncionarios_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8bb3bbf-97ac-46f5-9e58-dce74ea2f07f", "f4b7867a-3223-42c0-a0bf-6a793db7f5dd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "acf68d4b-9dbf-4f16-8696-34933f6815ae", "03083eb3-4bc2-44b7-883f-1726f988a1e1", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_BancoDeHoras_FuncionarioId",
                table: "BancoDeHoras",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_HorasFuncionarios_FuncionarioId",
                table: "HorasFuncionarios",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BancoDeHoras");

            migrationBuilder.DropTable(
                name: "HorasFuncionarios");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "acf68d4b-9dbf-4f16-8696-34933f6815ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8bb3bbf-97ac-46f5-9e58-dce74ea2f07f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd363aee-4900-4952-8461-d1ef75207373", "943625f6-8a41-4769-a93a-e6bd574fca3c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4d0d3ed-f8ff-4679-a20b-ca2009b52d1c", "bb0869eb-e324-4e82-8730-70eea2d9e389", "Admin", "ADMIN" });
        }
    }
}