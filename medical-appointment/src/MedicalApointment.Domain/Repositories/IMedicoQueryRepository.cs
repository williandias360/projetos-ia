using MedicalApointment.Domain.Models;

namespace MedicalApointment.Domain.Repositories;

public interface IMedicoQueryRepository
{
  Task<IEnumerable<Medico>> ListarTodosAsync();
}
