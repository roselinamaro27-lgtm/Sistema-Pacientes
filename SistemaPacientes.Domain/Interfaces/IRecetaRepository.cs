using SistemaPacientes.Domain;
namespace SistemaPacientes.Domain.Interfaces;

public interface IRecetaRepository
{
	Task<IEnumerable<Receta>> GetAllAsync();
	Task AddAsync(Receta entidad);
}