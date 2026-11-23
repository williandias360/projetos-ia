using System;
using MedicalApointment.Domain.Models;
using MedicalApointment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicalApointment.Infrastructure.Data.Repositories;

public class AgendamentoMedicoQueryRepository(AppDbContext _appDbContext) : IAgendamentoMedicoQueryRepository
{
  public async Task<IEnumerable<Agendamento>> ListarAgendamentosAsync()
  {
    return await _appDbContext
    .Agendamentos
    .AsNoTracking()
    .Include(a => a.Medico)
    .ToListAsync();
  }
}
