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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Paciente - Citas
			modelBuilder.Entity<Cita>()
				.HasOne(c => c.Paciente)
				.WithMany(p => p.Citas)
				.HasForeignKey(c => c.PacienteId)
				.OnDelete(DeleteBehavior.Restrict);

			// Paciente - Historiales médicos
			modelBuilder.Entity<HistorialMedico>()
				.HasOne(h => h.Paciente)
				.WithMany(p => p.HistorialesMedicos)
				.HasForeignKey(h => h.PacienteId)
				.OnDelete(DeleteBehavior.Restrict);

			// Médico - Citas
			modelBuilder.Entity<Cita>()
				.HasOne(c => c.Medico)
				.WithMany(m => m.Citas)
				.HasForeignKey(c => c.MedicoId)
				.OnDelete(DeleteBehavior.Restrict);

			// Especialidad - Médicos
			modelBuilder.Entity<Medico>()
				.HasOne(m => m.EspecialidadRelacion)
				.WithMany(e => e.Medicos)
				.HasForeignKey(m => m.EspecialidadId)
				.OnDelete(DeleteBehavior.Restrict);

			// Consultorio - Citas
			modelBuilder.Entity<Cita>()
				.HasOne(c => c.Consultorio)
				.WithMany(co => co.Citas)
				.HasForeignKey(c => c.ConsultorioId)
				.OnDelete(DeleteBehavior.Restrict);

			// Cita - Recetas
			modelBuilder.Entity<Receta>()
				.HasOne(r => r.Cita)
				.WithMany(c => c.Recetas)
				.HasForeignKey(r => r.CitaId)
				.OnDelete(DeleteBehavior.Restrict);

			// Rol - Usuarios
			modelBuilder.Entity<Usuario>()
				.HasOne(u => u.RolRelacion)
				.WithMany(r => r.Usuarios)
				.HasForeignKey(u => u.RolId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}