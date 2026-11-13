using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces
{
	public interface IEspecialidadRepository
	{
		Task<IEnumerable<Especialidad>> GetAllAsync();
		Task<Especialidad?> GetByIdAsync(int id);
		Task AddAsync(Especialidad entidad);
		Task UpdateAsync(Especialidad entidad);
		Task DeleteAsync(int id);
	}
}