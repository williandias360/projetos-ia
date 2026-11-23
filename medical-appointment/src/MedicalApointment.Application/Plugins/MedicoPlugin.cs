using System.ComponentModel;
using System.Text.Json;
using MedicalApointment.Application.UseCases;
using MedicalApointment.Application.UseCases.Medicos;
using Microsoft.SemanticKernel;

namespace MedicalApointment.Application.Plugins;

public class MedicoPlugin(
  ListarMedicosUseCase _listarMedicosUseCase,
  ListarMedicosAgendamentoUseCase _listarMedicosAgendamentoUseCase,
  ListarMedicosEspecialidadesUseCase _listarMedicosEspecialidadesUseCase
)
{
  [KernelFunction, Description("Lista todos os médicos disponíveis no banco de dados")]
  public async Task<string> ListarMedicosDisponiveis()
  {
    var listaMedicos = await _listarMedicosUseCase.Execute();
    return JsonSerializer.Serialize(listaMedicos);
  }

  [KernelFunction, Description("Lista os médicos com seus agendamentos e verifica horários disponíveis")]
  public async Task<string> ListarMedicosAgendamentos()
  {
    var listaMedicos = await _listarMedicosAgendamentoUseCase.Execute();
    return JsonSerializer.Serialize(listaMedicos);
  }

  [KernelFunction, Description("Lista os médicos com suas respectivas especialidades")]
  public async Task<string> ListarMedicosEspecialidades()
  {
    var listaMedicos = await _listarMedicosEspecialidadesUseCase.Execute();
    return JsonSerializer.Serialize(listaMedicos);
  }

}
