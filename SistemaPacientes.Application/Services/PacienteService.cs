using SistemaPacientes.Domain.Entities;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class PacienteService
	{
		private readonly IPacienteRepository _repository;

		public PacienteService(IPacienteRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Paciente>> GetAllPacientes() => await _repository.GetAllAsync();

		// Aquí puedes agregar lógica de negocio (ej: validaciones antes de guardar)
		public async Task AddPaciente(Paciente paciente)
		{
			// Ejemplo de lógica: validación simple
			if (string.IsNullOrEmpty(paciente.Nombre)) throw new Exception("El nombre es requerido");

			await _repository.AddAsync(paciente);
		}
	}
}