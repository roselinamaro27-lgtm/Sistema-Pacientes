using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories
{
	public class CitaRepository : ICitaRepository
	{
		private readonly ApplicationDbContext _context;

		public CitaRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Cita>> GetAllAsync()
		{
			return await _context.Citas.ToListAsync();
		}

		public async Task<Cita?> GetByIdAsync(int id)
		{
			return await _context.Citas.FindAsync(id);
		}

		public async Task AddAsync(Cita entidad)
		{
			await _context.Citas.AddAsync(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Cita entidad)
		{
			_context.Citas.Update(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entidad = await _context.Citas.FindAsync(id);

			if (entidad != null)
			{
				_context.Citas.Remove(entidad);
				await _context.SaveChangesAsync();
			}
		}
	}
}