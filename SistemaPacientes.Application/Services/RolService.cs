using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class RolService : IRolService
	{
		private readonly IRolRepository _repository;

		public RolService(IRolRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Rol>> GetAllRoles()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Rol?> GetRolById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddRol(Rol rol)
		{
			if (string.IsNullOrWhiteSpace(rol.NombreRol))
				throw new ArgumentException("El nombre del rol es requerido.");

			await _repository.AddAsync(rol);
		}

		public async Task UpdateRol(Rol rol)
		{
			var existente = await _repository.GetByIdAsync(rol.Id);

			if (existente == null)
				throw new KeyNotFoundException("Rol no encontrado.");

			if (string.IsNullOrWhiteSpace(rol.NombreRol))
				throw new ArgumentException("El nombre del rol es requerido.");

			await _repository.UpdateAsync(rol);
		}

		public async Task DeleteRol(int id)
		{
			var existente = await _repository.GetByIdAsync(id);

			if (existente == null)
				throw new KeyNotFoundException("Rol no encontrado.");

			await _repository.DeleteAsync(id);
		}
	}
}