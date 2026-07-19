namespace SistemaPacientes.Domain;

public class HistorialMedico
{
	public int Id { get; set; }
	public int PacienteId { get; set; }
	public string Diagnostico { get; set; }
	public string Observaciones { get; set; }
	public DateTime FechaRegistro { get; set; }
}