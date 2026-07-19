using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Infrastructure.Data;

namespace SistemaPacientes.Infrastructure.Repositories;

public class MedicoRepository : IMedicoRepository
{
	private readonly ApplicationDbContext _context;
	public MedicoRepository(ApplicationDbContext context) => _context = context;

	public async Task<IEnumerable<Medico>> GetAllAsync() => await _context.Medicos.ToListAsync();

	public async Task AddAsync(Medico entidad)
	{
		await _context.Medicos.AddAsync(entidad);
		await _context.SaveChangesAsync();
	}
}