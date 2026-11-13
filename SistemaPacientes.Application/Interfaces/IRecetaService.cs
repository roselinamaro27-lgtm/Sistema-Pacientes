using SistemaPacientes.Domain;

namespace SistemaPacientes.Application.Interfaces
{
	public interface IRecetaService
	{
		Task<IEnumerable<Receta>> GetAllRecetas();
		Task<Receta?> GetRecetaById(int id);
		Task AddReceta(Receta receta);
		Task UpdateReceta(Receta receta);
		Task DeleteReceta(int id);
	}
}