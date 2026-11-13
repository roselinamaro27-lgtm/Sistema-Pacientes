using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces
{
	public interface IMedicamentoRepository
	{
		Task<IEnumerable<Medicamento>> GetAllAsync();
		Task<Medicamento?> GetByIdAsync(int id);
		Task AddAsync(Medicamento entidad);
		Task UpdateAsync(Medicamento entidad);
		Task DeleteAsync(int id);
	}
}