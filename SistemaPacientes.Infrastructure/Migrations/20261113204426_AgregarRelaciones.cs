using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPacientes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspecialidadId",
                table: "Medicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsultorioId",
                table: "Citas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_CitaId",
                table: "Recetas",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadId",
                table: "Medicos",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesMedicos_PacienteId",
                table: "HistorialesMedicos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ConsultorioId",
                table: "Citas",
                column: "ConsultorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_MedicoId",
                table: "Citas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteId",
                table: "Citas",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Consultorios_ConsultorioId",
                table: "Citas",
                column: "ConsultorioId",
                principalTable: "Consultorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Medicos_MedicoId",
                table: "Citas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Pacientes_PacienteId",
                table: "Citas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialesMedicos_Pacientes_PacienteId",
                table: "HistorialesMedicos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadId",
                table: "Medicos",
                column: "EspecialidadId",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recetas_Citas_CitaId",
                table: "Recetas",
                column: "CitaId",
                principalTable: "Citas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Consultorios_ConsultorioId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Medicos_MedicoId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Pacientes_PacienteId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_HistorialesMedicos_Pacientes_PacienteId",
                table: "HistorialesMedicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadId",
                table: "Medicos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recetas_Citas_CitaId",
                table: "Recetas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Recetas_CitaId",
                table: "Recetas");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_EspecialidadId",
                table: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_HistorialesMedicos_PacienteId",
                table: "HistorialesMedicos");

            migrationBuilder.DropIndex(
                name: "IX_Citas_ConsultorioId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_MedicoId",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_PacienteId",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EspecialidadId",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "ConsultorioId",
                table: "Citas");
        }
    }
}
