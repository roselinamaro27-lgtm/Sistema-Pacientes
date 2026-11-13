using SistemaPacientes.Domain.Entities;
using SistemaPacientes.Domain.Entities;

namespace SistemaPacientes.Domain;

public class HistorialMedico
{
	public int Id { get; set; }
	public int PacienteId { get; set; }
	public string Diagnostico { get; set; } = string.Empty;
	public string Observaciones { get; set; } = string.Empty;
	public DateTime FechaRegistro { get; set; }

	// Relación
	public Paciente Paciente { get; set; }
}