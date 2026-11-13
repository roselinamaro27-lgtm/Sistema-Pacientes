using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces
{
	public interface IRecetaRepository
	{
		Task<IEnumerable<Receta>> GetAllAsync();
		Task<Receta?> GetByIdAsync(int id);
		Task AddAsync(Receta entidad);
		Task UpdateAsync(Receta entidad);
		Task DeleteAsync(int id);
	}
}