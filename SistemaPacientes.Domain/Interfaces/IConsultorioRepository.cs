using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces
{
	public interface IConsultorioRepository
	{
		Task<IEnumerable<Consultorio>> GetAllAsync();
		Task<Consultorio?> GetByIdAsync(int id);
		Task AddAsync(Consultorio entidad);
		Task UpdateAsync(Consultorio entidad);
		Task DeleteAsync(int id);
	}
}