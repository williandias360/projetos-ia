using System;
using MedicalApointment.Domain.Models;
using MedicalApointment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedicalApointment.Infrastructure.Data.Repositories;

public class MedicoQueryRepository : IMedicoQueryRepository
{
  private readonly AppDbContext _appDbContext;

  public MedicoQueryRepository(AppDbContext appDbContext)
  {
    _appDbContext = appDbContext;
  }

  public async Task<IEnumerable<Medico>> ListarTodosAsync()
  {
    return await _appDbContext
    .Medicos
    .AsNoTracking()
    .Include(e => e.MedicoEspecialidades)
    .ThenInclude(me => me.Especialidade)
    .Include(e => e.Agendamentos)
    .ThenInclude(a => a.Paciente)
    .ToListAsync();
  }
}
