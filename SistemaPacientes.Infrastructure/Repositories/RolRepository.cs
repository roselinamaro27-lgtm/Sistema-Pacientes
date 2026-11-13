using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories
{
	public class RolRepository : IRolRepository
	{
		private readonly ApplicationDbContext _context;

		public RolRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Rol>> GetAllAsync()
		{
			return await _context.Roles.ToListAsync();
		}

		public async Task<Rol?> GetByIdAsync(int id)
		{
			return await _context.Roles.FindAsync(id);
		}

		public async Task AddAsync(Rol entidad)
		{
			await _context.Roles.AddAsync(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Rol entidad)
		{
			_context.Roles.Update(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entidad = await _context.Roles.FindAsync(id);

			if (entidad != null)
			{
				_context.Roles.Remove(entidad);
				await _context.SaveChangesAsync();
			}
		}
	}
}