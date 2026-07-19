using SistemaPacientes.Domain;
namespace SistemaPacientes.Domain.Interfaces;

public interface IMedicamentoRepository
{
	Task<IEnumerable<Medicamento>> GetAllAsync();
	Task AddAsync(Medicamento entidad);
}