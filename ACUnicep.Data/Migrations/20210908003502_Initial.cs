using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACUnicep.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodigoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COD_NIVEL_ACESSO = table.Column<int>(type: "int", nullable: false),
                    ST_VALIDO = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodigoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    RA = table.Column<string>(type: "nchar(7)", fixedLength: true, maxLength: 7, nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    COD_USUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_CURSO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.RA);
                    table.ForeignKey(
                        name: "FK_Alunos_Usuarios_COD_USUARIO",
                        column: x => x.COD_USUARIO,
                        principalTable: "Usuarios",
                        principalColumn: "CodigoUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    COD_PROFESSOR = table.Column<string>(type: "nchar(7)", fixedLength: true, maxLength: 7, nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    COD_USUARIO = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.COD_PROFESSOR);
                    table.ForeignKey(
                        name: "FK_Professores_Usuarios_COD_USUARIO",
                        column: x => x.COD_USUARIO,
                        principalTable: "Usuarios",
                        principalColumn: "CodigoUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtividadesComplementares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    COD_TIPO_ATIVIDADE = table.Column<int>(type: "int", nullable: false),
                    COD_ALUNO = table.Column<string>(type: "nchar(7)", fixedLength: true, maxLength: 7, nullable: false),
                    COD_PROFESSOR = table.Column<string>(type: "nchar(7)", fixedLength: true, maxLength: 7, nullable: false),
                    QTD_HORAS = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CAMINHO_ARQUIVO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DT_SUBMISSAO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 7, 21, 35, 1, 719, DateTimeKind.Local).AddTicks(2940)),
                    DT_VALIDACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ST_VALIDA = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    OBSERVACOES = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadesComplementares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadesComplementares_Alunos_COD_ALUNO",
                        column: x => x.COD_ALUNO,
                        principalTable: "Alunos",
                        principalColumn: "RA",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtividadesComplementares_Professores_COD_PROFESSOR",
                        column: x => x.COD_PROFESSOR,
                        principalTable: "Professores",
                        principalColumn: "COD_PROFESSOR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_COD_USUARIO",
                table: "Alunos",
                column: "COD_USUARIO",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtividadesComplementares_COD_ALUNO",
                table: "AtividadesComplementares",
                column: "COD_ALUNO");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadesComplementares_COD_PROFESSOR",
                table: "AtividadesComplementares",
                column: "COD_PROFESSOR");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_COD_USUARIO",
                table: "Professores",
                column: "COD_USUARIO",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadesComplementares");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
