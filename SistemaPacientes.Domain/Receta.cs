namespace SistemaPacientes.Domain;

public class Receta
{
	public int Id { get; set; }
	public int CitaId { get; set; }
	public string Instrucciones { get; set; } = string.Empty;
	public DateTime FechaEmision { get; set; }

	// Relación
	public Cita Cita { get; set; }
}