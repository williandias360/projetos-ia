using System;

namespace MedicalApointment.Domain.Models;

public class Especialidade
{
  public int Id { get; set; }
  public string Descricao { get; set; } = string.Empty;
  public bool Ativo { get; set; }
  public ICollection<MedicoEspecialidade> MedicoEspecialidades { get; set; } = [];
}
