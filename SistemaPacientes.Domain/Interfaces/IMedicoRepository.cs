using SistemaPacientes.Domain;

namespace SistemaPacientes.Domain.Interfaces;

public interface IMedicoRepository
{
	Task<IEnumerable<Medico>> GetAllAsync();
	Task AddAsync(Medico entidad);
}