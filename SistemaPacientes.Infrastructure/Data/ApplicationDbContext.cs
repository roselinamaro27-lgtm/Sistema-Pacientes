using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Domain;
using SistemaPacientes.Domain.Entities;

namespace SistemaPacientes.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Paciente> Pacientes { get; set; }

		public DbSet<Medico> Medicos { get; set; }
		public DbSet<Especialidad> Especialidades { get; set; }

		public DbSet<Cita> Citas { get; set; }
		public DbSet<Consultorio> Consultorios { get; set; }
		public DbSet<Medicamento> Medicamentos { get; set; }
		public DbSet<Receta> Recetas { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Rol> Roles { get; set; }
		public DbSet<HistorialMedico> HistorialesMedicos { get; set; }
	}
}