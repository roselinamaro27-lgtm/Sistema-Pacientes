namespace SistemaPacientes.Domain;

public class Consultorio
{
	public int Id { get; set; }
	public string Numero { get; set; } = string.Empty;
	public string Piso { get; set; } = string.Empty;

	// Relación
	public ICollection<Cita> Citas { get; set; } = new List<Cita>();
}