namespace SistemaPacientes.Domain;

public class Medico
{
	public int Id { get; set; }
	public string Nombre { get; set; } = string.Empty;
	public string Especialidad { get; set; } = string.Empty;

	// Clave foránea
	public int? EspecialidadId { get; set; }

	// Relaciones
	public Especialidad? EspecialidadRelacion { get; set; }
	public ICollection<Cita> Citas { get; set; } = new List<Cita>();
}