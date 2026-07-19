using SistemaPacientes.Domain;
namespace SistemaPacientes.Domain.Interfaces;

public interface IUsuarioRepository
{
	Task<IEnumerable<Usuario>> GetAllAsync();
	Task AddAsync(Usuario entidad);
}