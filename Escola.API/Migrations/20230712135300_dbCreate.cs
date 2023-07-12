using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.API.Migrations
{
    public partial class dbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunoTB",
                columns: table => new
                {
                    PK_ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    SOBRENOME = table.Column<string>(type: "VARCHAR(150)", maxLength: 150, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    GENERO = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: true),
                    TELEFONE = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true),
                    EMAIL = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_aluno_id", x => x.PK_ID);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TURMA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CURSO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, defaultValue: "Curso Basico"),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TURMA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Boletins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aluno_FK = table.Column<int>(type: "INT", nullable: false),
                    DATA = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Boletins_AlunoTB_Aluno_FK",
                        column: x => x.Aluno_FK,
                        principalTable: "AlunoTB",
                        principalColumn: "PK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotasMaterias",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Boletim_ID = table.Column<int>(type: "INT", nullable: false),
                    Materia_ID = table.Column<int>(type: "INT", nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasMaterias", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NotasMaterias_Boletins_Boletim_ID",
                        column: x => x.Boletim_ID,
                        principalTable: "Boletins",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotasMaterias_Materias_Materia_ID",
                        column: x => x.Materia_ID,
                        principalTable: "Materias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTB_EMAIL",
                table: "AlunoTB",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boletins_Aluno_FK",
                table: "Boletins",
                column: "Aluno_FK");

            migrationBuilder.CreateIndex(
                name: "IX_NotasMaterias_Boletim_ID",
                table: "NotasMaterias",
                column: "Boletim_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NotasMaterias_Materia_ID",
                table: "NotasMaterias",
                column: "Materia_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TURMA_Nome",
                table: "TURMA",
                column: "Nome",
                unique: true,
                filter: "[Nome] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotasMaterias");

            migrationBuilder.DropTable(
                name: "TURMA");

            migrationBuilder.DropTable(
                name: "Boletins");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "AlunoTB");
        }
    }
}
