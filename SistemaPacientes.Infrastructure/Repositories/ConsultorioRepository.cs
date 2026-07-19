using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

public class ConsultorioRepository : IConsultorioRepository
{
	private readonly ApplicationDbContext _context;
	public ConsultorioRepository(ApplicationDbContext context) => _context = context;

	public async Task<IEnumerable<Consultorio>> GetAllAsync() => await _context.Consultorios.ToListAsync();
	public async Task AddAsync(Consultorio entidad) { await _context.Consultorios.AddAsync(entidad); await _context.SaveChangesAsync(); }
}