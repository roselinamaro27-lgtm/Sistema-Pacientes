using SistemaPacientes.Domain;

namespace SistemaPacientes.Application.Interfaces
{
	public interface IUsuarioService
	{
		Task<IEnumerable<Usuario>> GetAllUsuarios();
		Task<Usuario?> GetUsuarioById(int id);
		Task AddUsuario(Usuario usuario);
		Task UpdateUsuario(Usuario usuario);
		Task DeleteUsuario(int id);
	}
}