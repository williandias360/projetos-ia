namespace MedicalApointment.Domain.Models;

public class Paciente
{
  public int Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public virtual ICollection<Agendamento> Agendamentos { get; set; } = [];
}
