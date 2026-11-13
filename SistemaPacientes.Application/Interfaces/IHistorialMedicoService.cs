using SistemaPacientes.Domain;

namespace SistemaPacientes.Application.Interfaces
{
	public interface IHistorialMedicoService
	{
		Task<IEnumerable<HistorialMedico>> GetAllHistoriales();
		Task<HistorialMedico?> GetHistorialById(int id);
		Task AddHistorial(HistorialMedico historial);
		Task UpdateHistorial(HistorialMedico historial);
		Task DeleteHistorial(int id);
	}
}