
namespace MedicalApointment.Domain.Models;

public class Agendamento
{
  public int Id { get; set; }
  public string Motivo { get; set; } = string.Empty;
  public int PacienteId { get; set; }
  public Paciente Paciente { get; set; }
  public int MedicoId { get; set; }
  public Medico Medico { get; set; }
  public DateTime DataHora { get; set; }

}
