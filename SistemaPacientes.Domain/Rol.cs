namespace SistemaPacientes.Domain;

public class Rol
{
	public int Id { get; set; }
	public string NombreRol { get; set; } = string.Empty;

	// Relación
	public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}