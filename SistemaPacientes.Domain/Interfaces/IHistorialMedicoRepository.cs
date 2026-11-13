using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces
{
	public interface IHistorialMedicoRepository
	{
		Task<IEnumerable<HistorialMedico>> GetAllAsync();
		Task<HistorialMedico?> GetByIdAsync(int id);
		Task AddAsync(HistorialMedico entidad);
		Task UpdateAsync(HistorialMedico entidad);
		Task DeleteAsync(int id);
	}
}