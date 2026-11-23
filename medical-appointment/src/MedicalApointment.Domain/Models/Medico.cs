namespace MedicalApointment.Domain.Models;

public class Medico
{
  public int Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public virtual ICollection<MedicoEspecialidade> MedicoEspecialidades { get; set; } = [];
  public virtual ICollection<Agendamento> Agendamentos { get; set; } = [];

}
