using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories
{
	public class UsuarioRepository : IUsuarioRepository
	{
		private readonly ApplicationDbContext _context;

		public UsuarioRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Usuario>> GetAllAsync()
		{
			return await _context.Usuarios.ToListAsync();
		}

		public async Task<Usuario?> GetByIdAsync(int id)
		{
			return await _context.Usuarios.FindAsync(id);
		}

		public async Task AddAsync(Usuario entidad)
		{
			await _context.Usuarios.AddAsync(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Usuario entidad)
		{
			_context.Usuarios.Update(entidad);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entidad = await _context.Usuarios.FindAsync(id);

			if (entidad != null)
			{
				_context.Usuarios.Remove(entidad);
				await _context.SaveChangesAsync();
			}
		}
	}
}