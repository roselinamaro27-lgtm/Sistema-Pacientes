using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain.Entities;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class PacienteService : IPacienteService
	{
		private readonly IPacienteRepository _repository;

		public PacienteService(IPacienteRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Paciente>> GetAllPacientes()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Paciente?> GetPacienteById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddPaciente(Paciente paciente)
		{
			if (string.IsNullOrWhiteSpace(paciente.Nombre))
				throw new ArgumentException("El nombre es requerido.");

			await _repository.AddAsync(paciente);
		}

		public async Task UpdatePaciente(Paciente paciente)
		{
			var existente = await _repository.GetByIdAsync(paciente.Id);

			if (existente == null)
				throw new KeyNotFoundException("Paciente no encontrado.");

			if (string.IsNullOrWhiteSpace(paciente.Nombre))
				throw new ArgumentException("El nombre es requerido.");

			await _repository.UpdateAsync(paciente);
		}

		public async Task DeletePaciente(int id)
		{
			var existente = await _repository.GetByIdAsync(id);

			if (existente == null)
				throw new KeyNotFoundException("Paciente no encontrado.");

			await _repository.DeleteAsync(id);
		}
	}
}