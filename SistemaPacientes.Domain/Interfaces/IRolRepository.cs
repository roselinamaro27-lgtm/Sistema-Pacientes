using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces
{
	public interface IRolRepository
	{
		Task<IEnumerable<Rol>> GetAllAsync();
		Task<Rol?> GetByIdAsync(int id);
		Task AddAsync(Rol entidad);
		Task UpdateAsync(Rol entidad);
		Task DeleteAsync(int id);
	}
}