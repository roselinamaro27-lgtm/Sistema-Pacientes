using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces;

public interface IEspecialidadRepository
{
	Task<IEnumerable<Especialidad>> GetAllAsync();
	Task AddAsync(Especialidad entidad);
}