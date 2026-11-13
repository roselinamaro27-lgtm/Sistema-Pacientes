using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _repository;

		public UsuarioService(IUsuarioRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Usuario>> GetAllUsuarios()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Usuario?> GetUsuarioById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddUsuario(Usuario usuario)
		{
			if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
				throw new ArgumentException("El nombre de usuario es requerido.");

			if (string.IsNullOrWhiteSpace(usuario.Password))
				throw new ArgumentException("La contraseña es requerida.");

			if (string.IsNullOrWhiteSpace(usuario.Rol))
				throw new ArgumentException("El rol es requerido.");

			await _repository.AddAsync(usuario);
		}

		public async Task UpdateUsuario(Usuario usuario)
		{
			var existente = await _repository.GetByIdAsync(usuario.Id);

			if (existente == null)
				throw new KeyNotFoundException("Usuario no encontrado.");

			if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
				throw new ArgumentException("El nombre de usuario es requerido.");

			if (string.IsNullOrWhiteSpace(usuario.Password))
				throw new ArgumentException("La contraseña es requerida.");

			if (string.IsNullOrWhiteSpace(usuario.Rol))
				throw new ArgumentException("El rol es requerido.");

			await _repository.UpdateAsync(usuario);
		}

		public async Task DeleteUsuario(int id)
		{
			var existente = await _repository.GetByIdAsync(id);

			if (existente == null)
				throw new KeyNotFoundException("Usuario no encontrado.");

			await _repository.DeleteAsync(id);
		}
	}
}