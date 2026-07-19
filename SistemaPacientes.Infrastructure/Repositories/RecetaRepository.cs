using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

public class RecetaRepository : IRecetaRepository
{
	private readonly ApplicationDbContext _context;
	public RecetaRepository(ApplicationDbContext context) => _context = context;

	public async Task<IEnumerable<Receta>> GetAllAsync() => await _context.Recetas.ToListAsync();
	public async Task AddAsync(Receta entidad) { await _context.Recetas.AddAsync(entidad); await _context.SaveChangesAsync(); }
}