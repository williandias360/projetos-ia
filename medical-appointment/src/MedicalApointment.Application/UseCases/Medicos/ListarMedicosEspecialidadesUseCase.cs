using MedicalApointment.Application.UseCases.Medicos.ViewModel;
using MedicalApointment.Domain.Repositories;

namespace MedicalApointment.Application.UseCases;

public class ListarMedicosEspecialidadesUseCase(IMedicoQueryRepository _medicoQueryRepository)
{
  public async Task<IEnumerable<MedicoEspecialidadesViewModel>> Execute()
  {
    var listaMedicos = await _medicoQueryRepository.ListarTodosAsync();
    return listaMedicos.Select(m => new MedicoEspecialidadesViewModel(
      m.Id,
      m.Nome,
      m.MedicoEspecialidades.Select(e => e.Especialidade.Descricao)
    ));
  }
}
