using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories
{
	public class MedicoRepository : IMedicoRepository
	{
		private readonly ApplicationDbContext _context;

		public MedicoRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Medico>> GetAllAsync()
		{
			return await _context.Medicos.ToListAsync();
		}

		public async Task<Medico?> GetByIdAsync(int id)
		{
			return await _context.Medicos.FindAsync(id);
		}

		public async Task AddAsync(Medico entidad)
		{
			await _context.Medicos.AddAsync(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Medico entidad)
		{
			_context.Medicos.Update(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entidad = await _context.Medicos.FindAsync(id);

			if (entidad != null)
			{
				_context.Medicos.Remove(entidad);
				await _context.SaveChangesAsync();
			}
		}
	}
}