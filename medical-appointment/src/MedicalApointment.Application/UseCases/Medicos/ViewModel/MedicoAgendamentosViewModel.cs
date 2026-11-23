using MedicalApointment.Application.UseCases.Agendamento.ViewModel;

namespace MedicalApointment.Application.UseCases.Medicos.ViewModel;

public record MedicoAgendamentosViewModel(MedicoViewModel Medico, IEnumerable<AgendamentoViewModel> Agendamentos);
