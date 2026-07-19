using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces;

public interface IConsultorioRepository
{
	Task<IEnumerable<Consultorio>> GetAllAsync();
	Task AddAsync(Consultorio entidad);
}