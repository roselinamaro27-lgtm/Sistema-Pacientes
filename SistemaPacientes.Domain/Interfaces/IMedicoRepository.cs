using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces
{
	public interface IMedicoRepository
	{
		Task<IEnumerable<Medico>> GetAllAsync();
		Task<Medico?> GetByIdAsync(int id);
		Task AddAsync(Medico entidad);
		Task UpdateAsync(Medico entidad);
		Task DeleteAsync(int id);
	}
}