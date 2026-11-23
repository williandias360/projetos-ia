using MedicalApointment.Application.UseCases.Agendamento.ViewModel;
using MedicalApointment.Application.UseCases.Medicos.ViewModel;
using MedicalApointment.Domain.Repositories;

namespace MedicalApointment.Application.UseCases.Medicos;

public class ListarMedicosAgendamentoUseCase(IMedicoQueryRepository _medicoQueryRepository)
{
  public async Task<IEnumerable<MedicoAgendamentosViewModel>> Execute()
  {
    var listaMedicos = await _medicoQueryRepository.ListarTodosAsync();
    return listaMedicos.Select(m => new MedicoAgendamentosViewModel(
      new MedicoViewModel(m.Id, m.Nome),
      m.Agendamentos.Select(a => new AgendamentoViewModel(a.Paciente.Nome, a.DataHora, a.Motivo))
    ));
  }
}
