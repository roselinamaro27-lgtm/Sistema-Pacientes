using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

public class UsuarioRepository : IUsuarioRepository
{
	private readonly ApplicationDbContext _context;
	public UsuarioRepository(ApplicationDbContext context) => _context = context;

	public async Task<IEnumerable<Usuario>> GetAllAsync() => await _context.Usuarios.ToListAsync();
	public async Task AddAsync(Usuario entidad) { await _context.Usuarios.AddAsync(entidad); await _context.SaveChangesAsync(); }
}