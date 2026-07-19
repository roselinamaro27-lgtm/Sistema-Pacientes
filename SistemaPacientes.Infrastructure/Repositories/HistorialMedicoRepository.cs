using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

public class HistorialMedicoRepository : IHistorialMedicoRepository
{
	private readonly ApplicationDbContext _context;
	public HistorialMedicoRepository(ApplicationDbContext context) => _context = context;

	public async Task<IEnumerable<HistorialMedico>> GetAllAsync() => await _context.HistorialesMedicos.ToListAsync();
	public async Task AddAsync(HistorialMedico entidad) { await _context.HistorialesMedicos.AddAsync(entidad); await _context.SaveChangesAsync(); }
}