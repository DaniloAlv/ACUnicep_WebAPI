using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACUnicep.Data.Migrations
{
    public partial class AtualizaNomeColunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CodigoUsuario",
                table: "Usuarios",
                newName: "COD_USUARIO");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AtividadesComplementares",
                newName: "COD_ATIVIDADE_COMPLEMENTAR");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DT_SUBMISSAO",
                table: "AtividadesComplementares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 7, 21, 54, 12, 752, DateTimeKind.Local).AddTicks(1778),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 7, 21, 35, 1, 719, DateTimeKind.Local).AddTicks(2940));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COD_USUARIO",
                table: "Usuarios",
                newName: "CodigoUsuario");

            migrationBuilder.RenameColumn(
                name: "COD_ATIVIDADE_COMPLEMENTAR",
                table: "AtividadesComplementares",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DT_SUBMISSAO",
                table: "AtividadesComplementares",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 9, 7, 21, 35, 1, 719, DateTimeKind.Local).AddTicks(2940),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 9, 7, 21, 54, 12, 752, DateTimeKind.Local).AddTicks(1778));
        }
    }
}
