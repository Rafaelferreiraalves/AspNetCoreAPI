using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WepApi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    RequisitoId = table.Column<int>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    CursoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professor_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_RequisitoId",
                        column: x => x.RequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplina",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataIni = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplina", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 296, DateTimeKind.Local).AddTicks(8444), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(1214), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(1278), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(1284), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(1290), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 6, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(1300), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 7, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(1305), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 1, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 289, DateTimeKind.Local).AddTicks(5930), "Lauro", 1, "Oliveira" });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 2, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 290, DateTimeKind.Local).AddTicks(7546), "Roberto", 2, "Soares" });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 3, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 290, DateTimeKind.Local).AddTicks(7603), "Ronaldo", 3, "Marconi" });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 4, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 290, DateTimeKind.Local).AddTicks(7605), "Rodrigo", 4, "Carvalho" });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 5, true, null, new DateTime(2020, 6, 3, 21, 33, 8, 290, DateTimeKind.Local).AddTicks(7607), "Alexandre", 5, "Montanha" });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoID", "Nome", "ProfessorId", "RequisitoId" },
                values: new object[] { 1, 0, 1, "Matemática", 1, null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoID", "Nome", "ProfessorId", "RequisitoId" },
                values: new object[] { 2, 0, 3, "Matemática", 1, null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoID", "Nome", "ProfessorId", "RequisitoId" },
                values: new object[] { 3, 0, 3, "Física", 2, null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoID", "Nome", "ProfessorId", "RequisitoId" },
                values: new object[] { 4, 0, 1, "Português", 3, null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoID", "Nome", "ProfessorId", "RequisitoId" },
                values: new object[] { 5, 0, 1, "Inglês", 4, null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoID", "Nome", "ProfessorId", "RequisitoId" },
                values: new object[] { 6, 0, 2, "Inglês", 4, null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoID", "Nome", "ProfessorId", "RequisitoId" },
                values: new object[] { 7, 0, 3, "Inglês", 4, null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoID", "Nome", "ProfessorId", "RequisitoId" },
                values: new object[] { 8, 0, 1, "Programação", 5, null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoID", "Nome", "ProfessorId", "RequisitoId" },
                values: new object[] { 9, 0, 2, "Programação", 5, null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoID", "Nome", "ProfessorId", "RequisitoId" },
                values: new object[] { 10, 0, 3, "Programação", 5, null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 1, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3803), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 5, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3818), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 5, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3809), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 5, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3802), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 4, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3833), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 4, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3828), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 5, 4, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3819), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 4, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3817), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 4, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3763), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 3, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3832), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 5, 5, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3821), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 3, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3825), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 2, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3831), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 2, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3823), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 2, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3812), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 2, 2, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3805), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 1, 2, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(2940), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 1, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3829), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 6, 1, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3822), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 4, 1, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3816), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 1, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3811), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 3, 3, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3813), null });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni", "Nota" },
                values: new object[] { 7, 5, null, new DateTime(2020, 6, 3, 21, 33, 8, 297, DateTimeKind.Local).AddTicks(3835), null });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplina_DisciplinaId",
                table: "AlunoDisciplina",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoID",
                table: "Disciplinas",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_RequisitoId",
                table: "Disciplinas",
                column: "RequisitoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDisciplina");

            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
