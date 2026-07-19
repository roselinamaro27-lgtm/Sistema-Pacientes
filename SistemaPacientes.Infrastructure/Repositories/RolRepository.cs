using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

public class RolRepository : IRolRepository
{
	private readonly ApplicationDbContext _context;
	public RolRepository(ApplicationDbContext context) => _context = context;

	public async Task<IEnumerable<Rol>> GetAllAsync() => await _context.Roles.ToListAsync();
	public async Task AddAsync(Rol entidad) { await _context.Roles.AddAsync(entidad); await _context.SaveChangesAsync(); }
}