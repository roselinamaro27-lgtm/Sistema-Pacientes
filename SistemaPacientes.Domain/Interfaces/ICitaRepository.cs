using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces
{
	public interface ICitaRepository
	{
		Task<IEnumerable<Cita>> GetAllAsync();
		Task<Cita?> GetByIdAsync(int id);
		Task AddAsync(Cita entidad);
		Task UpdateAsync(Cita entidad);
		Task DeleteAsync(int id);
	}
}