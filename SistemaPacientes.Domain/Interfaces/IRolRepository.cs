using SistemaPacientes.Domain;
namespace SistemaPacientes.Domain.Interfaces;

public interface IRolRepository
{
	Task<IEnumerable<Rol>> GetAllAsync();
	Task AddAsync(Rol entidad);
}