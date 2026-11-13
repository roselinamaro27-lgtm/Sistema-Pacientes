using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories
{
	public class MedicamentoRepository : IMedicamentoRepository
	{
		private readonly ApplicationDbContext _context;

		public MedicamentoRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Medicamento>> GetAllAsync()
		{
			return await _context.Medicamentos.ToListAsync();
		}

		public async Task<Medicamento?> GetByIdAsync(int id)
		{
			return await _context.Medicamentos.FindAsync(id);
		}

		public async Task AddAsync(Medicamento entidad)
		{
			await _context.Medicamentos.AddAsync(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Medicamento entidad)
		{
			_context.Medicamentos.Update(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entidad = await _context.Medicamentos.FindAsync(id);

			if (entidad != null)
			{
				_context.Medicamentos.Remove(entidad);
				await _context.SaveChangesAsync();
			}
		}
	}
}