using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Calculador_de_Horas.Migrations
{
    public partial class inclusaodealmoco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BancoDeHoras_Funcionario_FuncionarioId",
                table: "BancoDeHoras");

            migrationBuilder.DropForeignKey(
                name: "FK_HorasFuncionarios_Funcionario_FuncionarioId",
                table: "HorasFuncionarios");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "HorasFuncionarios",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "AlmocoRetorno",
                table: "HorasFuncionarios",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "AlmocoSaida",
                table: "HorasFuncionarios",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "BancoDeHoras",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BancoDeHoras_Funcionario_FuncionarioId",
                table: "BancoDeHoras",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HorasFuncionarios_Funcionario_FuncionarioId",
                table: "HorasFuncionarios",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BancoDeHoras_Funcionario_FuncionarioId",
                table: "BancoDeHoras");

            migrationBuilder.DropForeignKey(
                name: "FK_HorasFuncionarios_Funcionario_FuncionarioId",
                table: "HorasFuncionarios");

            migrationBuilder.DropColumn(
                name: "AlmocoRetorno",
                table: "HorasFuncionarios");

            migrationBuilder.DropColumn(
                name: "AlmocoSaida",
                table: "HorasFuncionarios");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "HorasFuncionarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "BancoDeHoras",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BancoDeHoras_Funcionario_FuncionarioId",
                table: "BancoDeHoras",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorasFuncionarios_Funcionario_FuncionarioId",
                table: "HorasFuncionarios",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
