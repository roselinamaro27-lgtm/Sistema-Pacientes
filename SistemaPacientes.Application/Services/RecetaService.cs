using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.Application.Services
{
	public class RecetaService : IRecetaService
	{
		private readonly IRecetaRepository _repository;

		public RecetaService(IRecetaRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Receta>> GetAllRecetas()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Receta?> GetRecetaById(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task AddReceta(Receta receta)
		{
			if (string.IsNullOrWhiteSpace(receta.Instrucciones))
				throw new ArgumentException("Las instrucciones son requeridas.");

			await _repository.AddAsync(receta);
		}

		public async Task UpdateReceta(Receta receta)
		{
			var existente = await _repository.GetByIdAsync(receta.Id);

			if (existente == null)
				throw new KeyNotFoundException("Receta no encontrada.");

			if (string.IsNullOrWhiteSpace(receta.Instrucciones))
				throw new ArgumentException("Las instrucciones son requeridas.");

			await _repository.UpdateAsync(receta);
		}

		public async Task DeleteReceta(int id)
		{
			var existente = await _repository.GetByIdAsync(id);

			if (existente == null)
				throw new KeyNotFoundException("Receta no encontrada.");

			await _repository.DeleteAsync(id);
		}
	}
}