using SistemaPacientes.Domain;
namespace SistemaPacientes.Domain.Interfaces;

public interface IHistorialMedicoRepository
{
	Task<IEnumerable<HistorialMedico>> GetAllAsync();
	Task AddAsync(HistorialMedico entidad);
}