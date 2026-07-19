using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces;

public interface ICitaRepository
{
	Task<IEnumerable<Cita>> GetAllAsync();
	Task AddAsync(Cita entidad);
}