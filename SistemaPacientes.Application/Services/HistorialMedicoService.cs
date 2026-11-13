using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class HistorialMedicoService : IHistorialMedicoService
	{
		private readonly IHistorialMedicoRepository _repository;

		public HistorialMedicoService(IHistorialMedicoRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<HistorialMedico>> GetAllHistoriales()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<HistorialMedico?> GetHistorialById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddHistorial(HistorialMedico historial)
		{
			if (string.IsNullOrWhiteSpace(historial.Diagnostico))
				throw new ArgumentException("El diagnóstico es requerido.");

			await _repository.AddAsync(historial);
		}

		public async Task UpdateHistorial(HistorialMedico historial)
		{
			var existente = await _repository.GetByIdAsync(historial.Id);

			if (existente == null)
				throw new KeyNotFoundException("Historial médico no encontrado.");

			if (string.IsNullOrWhiteSpace(historial.Diagnostico))
				throw new ArgumentException("El diagnóstico es requerido.");

			await _repository.UpdateAsync(historial);
		}

		public async Task DeleteHistorial(int id)
		{
			var existente = await _repository.GetByIdAsync(id);

			if (existente == null)
				throw new KeyNotFoundException("Historial médico no encontrado.");

			await _repository.DeleteAsync(id);
		}
	}
}