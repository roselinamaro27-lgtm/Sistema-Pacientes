using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories
{
	public class HistorialMedicoRepository : IHistorialMedicoRepository
	{
		private readonly ApplicationDbContext _context;

		public HistorialMedicoRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<HistorialMedico>> GetAllAsync()
		{
			return await _context.HistorialesMedicos.ToListAsync();
		}

		public async Task<HistorialMedico?> GetByIdAsync(int id)
		{
			return await _context.HistorialesMedicos.FindAsync(id);
		}

		public async Task AddAsync(HistorialMedico entidad)
		{
			await _context.HistorialesMedicos.AddAsync(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(HistorialMedico entidad)
		{
			_context.HistorialesMedicos.Update(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entidad = await _context.HistorialesMedicos.FindAsync(id);

			if (entidad != null)
			{
				_context.HistorialesMedicos.Remove(entidad);
				await _context.SaveChangesAsync();
			}
		}
	}
}