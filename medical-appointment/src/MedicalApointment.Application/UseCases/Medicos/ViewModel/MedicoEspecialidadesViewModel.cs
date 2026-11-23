namespace MedicalApointment.Application.UseCases.Medicos.ViewModel;

public record MedicoEspecialidadesViewModel(int Id, string Nome, IEnumerable<string> Especialidades);
