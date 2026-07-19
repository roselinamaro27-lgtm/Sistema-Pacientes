using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories;

public class EspecialidadRepository : IEspecialidadRepository
{
	private readonly ApplicationDbContext _context;
	public EspecialidadRepository(ApplicationDbContext context) => _context = context;

	public async Task<IEnumerable<Especialidad>> GetAllAsync() => await _context.Especialidades.ToListAsync();
	public async Task AddAsync(Especialidad entidad) { await _context.Especialidades.AddAsync(entidad); await _context.SaveChangesAsync(); }
}