using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class MedicoService : IMedicoService
	{
		private readonly IMedicoRepository _repository;

		public MedicoService(IMedicoRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Medico>> GetAllMedicos()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Medico?> GetMedicoById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddMedico(Medico medico)
		{
			if (string.IsNullOrWhiteSpace(medico.Nombre))
				throw new ArgumentException("El nombre es requerido.");

			if (string.IsNullOrWhiteSpace(medico.Especialidad))
				throw new ArgumentException("La especialidad es requerida.");

			await _repository.AddAsync(medico);
		}

		public async Task UpdateMedico(Medico medico)
		{
			var existente = await _repository.GetByIdAsync(medico.Id);

			if (existente == null)
				throw new KeyNotFoundException("Médico no encontrado.");

			if (string.IsNullOrWhiteSpace(medico.Nombre))
				throw new ArgumentException("El nombre es requerido.");

			if (string.IsNullOrWhiteSpace(medico.Especialidad))
				throw new ArgumentException("La especialidad es requerida.");

			await _repository.UpdateAsync(medico);
		}

		public async Task DeleteMedico(int id)
		{
			var existente = await _repository.GetByIdAsync(id);

			if (existente == null)
				throw new KeyNotFoundException("Médico no encontrado.");

			await _repository.DeleteAsync(id);
		}
	}
}