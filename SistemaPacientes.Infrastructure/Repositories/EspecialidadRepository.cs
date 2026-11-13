using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories
{
	public class EspecialidadRepository : IEspecialidadRepository
	{
		private readonly ApplicationDbContext _context;

		public EspecialidadRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Especialidad>> GetAllAsync()
		{
			return await _context.Especialidades.ToListAsync();
		}

		public async Task<Especialidad?> GetByIdAsync(int id)
		{
			return await _context.Especialidades.FindAsync(id);
		}

		public async Task AddAsync(Especialidad entidad)
		{
			await _context.Especialidades.AddAsync(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Especialidad entidad)
		{
			_context.Especialidades.Update(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entidad = await _context.Especialidades.FindAsync(id);

			if (entidad != null)
			{
				_context.Especialidades.Remove(entidad);
				await _context.SaveChangesAsync();
			}
		}
	}
}