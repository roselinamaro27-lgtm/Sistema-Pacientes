using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories
{
	public class RecetaRepository : IRecetaRepository
	{
		private readonly ApplicationDbContext _context;

		public RecetaRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Receta>> GetAllAsync()
		{
			return await _context.Recetas.ToListAsync();
		}

		public async Task<Receta?> GetByIdAsync(int id)
		{
			return await _context.Recetas.FindAsync(id);
		}

		public async Task AddAsync(Receta entidad)
		{
			await _context.Recetas.AddAsync(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Receta entidad)
		{
			_context.Recetas.Update(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entidad = await _context.Recetas.FindAsync(id);

			if (entidad != null)
			{
				_context.Recetas.Remove(entidad);
				await _context.SaveChangesAsync();
			}
		}
	}
}