namespace SistemaPacientes.Domain;

public class Especialidad
{
	public int Id { get; set; }
	public string Nombre { get; set; } = string.Empty;
	public string Descripcion { get; set; } = string.Empty;

	// Relación
	public ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}