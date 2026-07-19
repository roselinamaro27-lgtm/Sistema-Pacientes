using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

public class MedicamentoRepository : IMedicamentoRepository
{
	private readonly ApplicationDbContext _context;
	public MedicamentoRepository(ApplicationDbContext context) => _context = context;

	public async Task<IEnumerable<Medicamento>> GetAllAsync() => await _context.Medicamentos.ToListAsync();
	public async Task AddAsync(Medicamento entidad) { await _context.Medicamentos.AddAsync(entidad); await _context.SaveChangesAsync(); }
}