using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class ConsultorioService : IConsultorioService
	{
		private readonly IConsultorioRepository _repository;

		public ConsultorioService(IConsultorioRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Consultorio>> GetAllConsultorios()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Consultorio?> GetConsultorioById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddConsultorio(Consultorio consultorio)
		{
			if (string.IsNullOrWhiteSpace(consultorio.Numero))
				throw new ArgumentException("El número del consultorio es requerido.");

			await _repository.AddAsync(consultorio);
		}

		public async Task UpdateConsultorio(Consultorio consultorio)
		{
			var existente = await _repository.GetByIdAsync(consultorio.Id);

			if (existente == null)
				throw new KeyNotFoundException("Consultorio no encontrado.");

			if (string.IsNullOrWhiteSpace(consultorio.Numero))
				throw new ArgumentException("El número del consultorio es requerido.");

			await _repository.UpdateAsync(consultorio);
		}

		public async Task DeleteConsultorio(int id)
		{
			var existente = await _repository.GetByIdAsync(id);

			if (existente == null)
				throw new KeyNotFoundException("Consultorio no encontrado.");

			await _repository.DeleteAsync(id);
		}
	}
}