using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces
{
	public interface IUsuarioRepository
	{
		Task<IEnumerable<Usuario>> GetAllAsync();
		Task<Usuario?> GetByIdAsync(int id);
		Task AddAsync(Usuario entidad);
		Task UpdateAsync(Usuario entidad);
		Task DeleteAsync(int id);
	}
}