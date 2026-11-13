using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories
{
	public class ConsultorioRepository : IConsultorioRepository
	{
		private readonly ApplicationDbContext _context;

		public ConsultorioRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Consultorio>> GetAllAsync()
		{
			return await _context.Consultorios.ToListAsync();
		}

		public async Task<Consultorio?> GetByIdAsync(int id)
		{
			return await _context.Consultorios.FindAsync(id);
		}

		public async Task AddAsync(Consultorio entidad)
		{
			await _context.Consultorios.AddAsync(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Consultorio entidad)
		{
			_context.Consultorios.Update(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entidad = await _context.Consultorios.FindAsync(id);

			if (entidad != null)
			{
				_context.Consultorios.Remove(entidad);
				await _context.SaveChangesAsync();
			}
		}
	}
}