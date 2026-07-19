using SistemaPacientes.Domain;
using SistemaPacientes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain.Interfaces;

public class CitaRepository : ICitaRepository
{
	private readonly ApplicationDbContext _context;
	public CitaRepository(ApplicationDbContext context) => _context = context;
	public async Task<IEnumerable<Cita>> GetAllAsync() => await _context.Citas.ToListAsync();
	public async Task AddAsync(Cita entidad) { await _context.Citas.AddAsync(entidad); await _context.SaveChangesAsync(); }
}