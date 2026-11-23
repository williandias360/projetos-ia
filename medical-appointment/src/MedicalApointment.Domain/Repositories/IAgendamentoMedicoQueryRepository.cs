using MedicalApointment.Domain.Models;

namespace MedicalApointment.Domain.Repositories;

public interface IAgendamentoMedicoQueryRepository
{
  Task<IEnumerable<Agendamento>> ListarAgendamentosAsync();
}
