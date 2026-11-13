using SistemaPacientes.Domain.Entities;
using SistemaPacientes.Domain.Entities;

namespace SistemaPacientes.Domain;

public class Cita
{
	public int Id { get; set; }
	public DateTime Fecha { get; set; }
	public string Motivo { get; set; } = string.Empty;

	// Claves foráneas
	public int PacienteId { get; set; }
	public int MedicoId { get; set; }
	public int? ConsultorioId { get; set; }

	// Relaciones
	public Paciente Paciente { get; set; }
	public Medico Medico { get; set; }
	public Consultorio? Consultorio { get; set; }

	public ICollection<Receta> Recetas { get; set; } = new List<Receta>();
}