using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class EspecialidadService : IEspecialidadService
	{
		private readonly IEspecialidadRepository _repository;

		public EspecialidadService(IEspecialidadRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Especialidad>> GetAllEspecialidades()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Especialidad?> GetEspecialidadById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddEspecialidad(Especialidad especialidad)
		{
			if (string.IsNullOrWhiteSpace(especialidad.Nombre))
				throw new ArgumentException("El nombre es requerido.");

			await _repository.AddAsync(especialidad);
		}

		public async Task UpdateEspecialidad(Especialidad especialidad)
		{
			var existente = await _repository.GetByIdAsync(especialidad.Id);

			if (existente == null)
				throw new KeyNotFoundException("Especialidad no encontrada.");

			if (string.IsNullOrWhiteSpace(especialidad.Nombre))
				throw new ArgumentException("El nombre es requerido.");

			await _repository.UpdateAsync(especialidad);
		}

		public async Task DeleteEspecialidad(int id)
		{
			var existente = await _repository.GetByIdAsync(id);

			if (existente == null)
				throw new KeyNotFoundException("Especialidad no encontrada.");

			await _repository.DeleteAsync(id);
		}
	}
}