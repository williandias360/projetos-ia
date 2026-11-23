using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalApointment.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Ajustandonomedascolunasmedico_idepaciente_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_medicos_MedicoId",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_pacientes_PacienteId",
                table: "agendamentos");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "agendamentos",
                newName: "id_paciente");

            migrationBuilder.RenameColumn(
                name: "MedicoId",
                table: "agendamentos",
                newName: "id_medico");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_PacienteId",
                table: "agendamentos",
                newName: "IX_agendamentos_id_paciente");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_MedicoId",
                table: "agendamentos",
                newName: "IX_agendamentos_id_medico");

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_medicos_id_medico",
                table: "agendamentos",
                column: "id_medico",
                principalTable: "medicos",
                principalColumn: "id_medico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_pacientes_id_paciente",
                table: "agendamentos",
                column: "id_paciente",
                principalTable: "pacientes",
                principalColumn: "id_paciente",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_medicos_id_medico",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_pacientes_id_paciente",
                table: "agendamentos");

            migrationBuilder.RenameColumn(
                name: "id_paciente",
                table: "agendamentos",
                newName: "PacienteId");

            migrationBuilder.RenameColumn(
                name: "id_medico",
                table: "agendamentos",
                newName: "MedicoId");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_id_paciente",
                table: "agendamentos",
                newName: "IX_agendamentos_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_id_medico",
                table: "agendamentos",
                newName: "IX_agendamentos_MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_medicos_MedicoId",
                table: "agendamentos",
                column: "MedicoId",
                principalTable: "medicos",
                principalColumn: "id_medico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_agendamentos_pacientes_PacienteId",
                table: "agendamentos",
                column: "PacienteId",
                principalTable: "pacientes",
                principalColumn: "id_paciente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
