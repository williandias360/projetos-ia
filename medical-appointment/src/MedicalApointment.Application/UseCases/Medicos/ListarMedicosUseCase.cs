using MedicalApointment.Application.UseCases.Medicos.ViewModel;
using MedicalApointment.Domain.Repositories;

namespace MedicalApointment.Application.UseCases;

public class ListarMedicosUseCase(IMedicoQueryRepository _medicoQueryRepository)
{
  public async Task<IEnumerable<MedicoViewModel>> Execute()
  {
    var listaMedicos = await _medicoQueryRepository.ListarTodosAsync();
    return listaMedicos.Select(m => new MedicoViewModel(m.Id, m.Nome));
  }
}
