using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class CitaService : ICitaService
	{
		private readonly ICitaRepository _repository;

		public CitaService(ICitaRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Cita>> GetAllCitas()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Cita?> GetCitaById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddCita(Cita cita)
		{
			if (string.IsNullOrWhiteSpace(cita.Motivo))
				throw new ArgumentException("El motivo es requerido.");

			await _repository.AddAsync(cita);
		}

		public async Task UpdateCita(Cita cita)
		{
			var existente = await _repository.GetByIdAsync(cita.Id);

			if (existente == null)
				throw new KeyNotFoundException("Cita no encontrada.");

			if (string.IsNullOrWhiteSpace(cita.Motivo))
				throw new ArgumentException("El motivo es requerido.");

			await _repository.UpdateAsync(cita);
		}

		public async Task DeleteCita(int id)
		{
			var existente = await _repository.GetByIdAsync(id);

			if (existente == null)
				throw new KeyNotFoundException("Cita no encontrada.");

			await _repository.DeleteAsync(id);
		}
	}
}