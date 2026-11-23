using MedicalApointment.Application.UseCases;
using MedicalApointment.Application.UseCases.Medicos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalApointment.WebApi.Endpoints;

public static class MedicoEndpoints
{
  public static void MapMedicoEndpoint(this IEndpointRouteBuilder routes)
  {
    var group = routes.MapGroup("/medicos");
    group.MapGet("/", async ([FromServices] ListarMedicosUseCase medicoUseCase) => await medicoUseCase.Execute());
    group.MapGet("/especialidades", async ([FromServices] ListarMedicosEspecialidadesUseCase medicosEspecialidadesUseCase) => await medicosEspecialidadesUseCase.Execute());
    group.MapGet("/agendamentos", async ([FromServices] ListarMedicosAgendamentoUseCase medicosAgendamentoUseCase) => await medicosAgendamentoUseCase.Execute());
  }
}
