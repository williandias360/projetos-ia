using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalApointment.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Pacientes_PacienteId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_medicos_MedicoId",
                table: "Agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicoEspecialidades_especialidades_id_especialidade",
                table: "MedicoEspecialidades");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicoEspecialidades_medicos_id_medico",
                table: "MedicoEspecialidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicoEspecialidades",
                table: "MedicoEspecialidades");

            migrationBuilder.RenameTable(
                name: "Pacientes",
                newName: "pacientes");

            migrationBuilder.RenameTable(
                name: "Agendamentos",
                newName: "agendamentos");

            migrationBuilder.RenameTable(
                name: "MedicoEspecialidades",
                newName: "medicos_especialidades");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_PacienteId",
                table: "agendamentos",
                newName: "IX_agendamentos_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_MedicoId",
                table: "agendamentos",
                newName: "IX_agendamentos_MedicoId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicoEspecialidades_id_medico",
                table: "medicos_especialidades",
                newName: "IX_medicos_especialidades_id_medico");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:vector", ",,");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pacientes",
                table: "pacientes",
                column: "id_paciente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agendamentos",
                table: "agendamentos",
                column: "id_agendamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicos_especialidades",
                table: "medicos_especialidades",
                columns: new[] { "id_especialidade", "id_medico" });

            migrationBuilder.InsertData(
                table: "especialidades",
                columns: new[] { "id_especialidade", "ativo", "descricao" },
                values: new object[,]
                {
                    { 1, true, "Cardiologista" },
                    { 2, true, "Urologista" },
                    { 3, true, "Pediatra" },
                    { 4, true, "Neurologista" },
                    { 5, true, "Neurocirurgião" },
                    { 6, true, "Ortopedista e Traumotologia" },
                    { 7, true, "Ginecologia e Obstretícia" },
                    { 8, true, "Nefrologista" },
                    { 9, true, "Anestesiologia" },
                    { 10, true, "Clinico Geral" }
                });

            migrationBuilder.InsertData(
                table: "medicos",
                columns: new[] { "id_medico", "nome" },
                values: new object[,]
                {
                    { 1, "Camila Oliveira Santos" },
                    { 2, "Thiago Rezende Costa" },
                    { 3, "Mariana Frota Albuquerque" },
                    { 4, "Rodrigo Pires Nogueira" },
                    { 5, "Letícia Dornelles Schivittz" }
                });

            migrationBuilder.InsertData(
                table: "pacientes",
                columns: new[] { "id_paciente", "nome" },
                values: new object[,]
                {
                    { 1, "Bruno Medeiros Viera" },
                    { 2, "Larissa Couto Fagundes" },
                    { 3, "Felipe Fontana Castro" },
                    { 4, "Beatriz Vasconcelos Lima" },
                    { 5, "Gabriel Silveira Antunes" },
                    { 6, "Amanda Prestes Guimarães" },
                    { 7, "Ricardo Junqueira Neto" },
                    { 8, "Juliana Meirels Rocha" },
                    { 9, "Matheus Albuquerque Lins" },
                    { 10, "Carolina Viana Dornelles" }
                });

            migrationBuilder.InsertData(
                table: "agendamentos",
                columns: new[] { "id_agendamento", "data_hora", "MedicoId", "motivo", "PacienteId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 22, 8, 30, 0, 0, DateTimeKind.Unspecified), 1, "Rotina", 2 },
                    { 2, new DateTime(2026, 10, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, "Retorno", 3 },
                    { 3, new DateTime(2026, 10, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), 2, "Rotina", 1 },
                    { 4, new DateTime(2026, 10, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, "Rotina", 4 }
                });

            migrationBuilder.InsertData(
                table: "medicos_especialidades",
                columns: new[] { "id_especialidade", "id_medico" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_medicos_especialidades_especialidades_id_especialidade",
                table: "medicos_especialidades",
                column: "id_especialidade",
                principalTable: "especialidades",
                principalColumn: "id_especialidade",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_medicos_especialidades_medicos_id_medico",
                table: "medicos_especialidades",
                column: "id_medico",
                principalTable: "medicos",
                principalColumn: "id_medico",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_medicos_MedicoId",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_agendamentos_pacientes_PacienteId",
                table: "agendamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_medicos_especialidades_especialidades_id_especialidade",
                table: "medicos_especialidades");

            migrationBuilder.DropForeignKey(
                name: "FK_medicos_especialidades_medicos_id_medico",
                table: "medicos_especialidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pacientes",
                table: "pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agendamentos",
                table: "agendamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medicos_especialidades",
                table: "medicos_especialidades");

            migrationBuilder.DeleteData(
                table: "agendamentos",
                keyColumn: "id_agendamento",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "agendamentos",
                keyColumn: "id_agendamento",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "agendamentos",
                keyColumn: "id_agendamento",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "agendamentos",
                keyColumn: "id_agendamento",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "especialidades",
                keyColumn: "id_especialidade",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "especialidades",
                keyColumn: "id_especialidade",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "especialidades",
                keyColumn: "id_especialidade",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "especialidades",
                keyColumn: "id_especialidade",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "especialidades",
                keyColumn: "id_especialidade",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "medicos_especialidades",
                keyColumns: new[] { "id_especialidade", "id_medico" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "medicos_especialidades",
                keyColumns: new[] { "id_especialidade", "id_medico" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "medicos_especialidades",
                keyColumns: new[] { "id_especialidade", "id_medico" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "medicos_especialidades",
                keyColumns: new[] { "id_especialidade", "id_medico" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "medicos_especialidades",
                keyColumns: new[] { "id_especialidade", "id_medico" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "pacientes",
                keyColumn: "id_paciente",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "pacientes",
                keyColumn: "id_paciente",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "pacientes",
                keyColumn: "id_paciente",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "pacientes",
                keyColumn: "id_paciente",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "pacientes",
                keyColumn: "id_paciente",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "pacientes",
                keyColumn: "id_paciente",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "especialidades",
                keyColumn: "id_especialidade",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "especialidades",
                keyColumn: "id_especialidade",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "especialidades",
                keyColumn: "id_especialidade",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "especialidades",
                keyColumn: "id_especialidade",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "especialidades",
                keyColumn: "id_especialidade",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "medicos",
                keyColumn: "id_medico",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "medicos",
                keyColumn: "id_medico",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "medicos",
                keyColumn: "id_medico",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "medicos",
                keyColumn: "id_medico",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "medicos",
                keyColumn: "id_medico",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "pacientes",
                keyColumn: "id_paciente",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "pacientes",
                keyColumn: "id_paciente",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "pacientes",
                keyColumn: "id_paciente",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pacientes",
                keyColumn: "id_paciente",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "pacientes",
                newName: "Pacientes");

            migrationBuilder.RenameTable(
                name: "agendamentos",
                newName: "Agendamentos");

            migrationBuilder.RenameTable(
                name: "medicos_especialidades",
                newName: "MedicoEspecialidades");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_PacienteId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_agendamentos_MedicoId",
                table: "Agendamentos",
                newName: "IX_Agendamentos_MedicoId");

            migrationBuilder.RenameIndex(
                name: "IX_medicos_especialidades_id_medico",
                table: "MedicoEspecialidades",
                newName: "IX_MedicoEspecialidades_id_medico");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:vector", ",,");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pacientes",
                table: "Pacientes",
                column: "id_paciente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos",
                column: "id_agendamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicoEspecialidades",
                table: "MedicoEspecialidades",
                columns: new[] { "id_especialidade", "id_medico" });

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Pacientes_PacienteId",
                table: "Agendamentos",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "id_paciente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_medicos_MedicoId",
                table: "Agendamentos",
                column: "MedicoId",
                principalTable: "medicos",
                principalColumn: "id_medico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoEspecialidades_especialidades_id_especialidade",
                table: "MedicoEspecialidades",
                column: "id_especialidade",
                principalTable: "especialidades",
                principalColumn: "id_especialidade",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicoEspecialidades_medicos_id_medico",
                table: "MedicoEspecialidades",
                column: "id_medico",
                principalTable: "medicos",
                principalColumn: "id_medico",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
