using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class MedicamentoService : IMedicamentoService
	{
		private readonly IMedicamentoRepository _repository;

		public MedicamentoService(IMedicamentoRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Medicamento>> GetAllMedicamentos()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Medicamento?> GetMedicamentoById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddMedicamento(Medicamento medicamento)
		{
			if (string.IsNullOrWhiteSpace(medicamento.Nombre))
				throw new ArgumentException("El nombre es requerido.");

			await _repository.AddAsync(medicamento);
		}

		public async Task UpdateMedicamento(Medicamento medicamento)
		{
			var existente = await _repository.GetByIdAsync(medicamento.Id);

			if (existente == null)
				throw new KeyNotFoundException("Medicamento no encontrado.");

			if (string.IsNullOrWhiteSpace(medicamento.Nombre))
				throw new ArgumentException("El nombre es requerido.");

			await _repository.UpdateAsync(medicamento);
		}

		public async Task DeleteMedicamento(int id)
		{
			var existente = await _repository.GetByIdAsync(id);

			if (existente == null)
				throw new KeyNotFoundException("Medicamento no encontrado.");

			await _repository.DeleteAsync(id);
		}
	}
}