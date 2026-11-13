namespace SistemaPacientes.Domain;

public class Usuario
{
	public int Id { get; set; }
	public string NombreUsuario { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string Rol { get; set; } = string.Empty;

	// Clave foránea
	public int? RolId { get; set; }

	// Relación
	public Rol? RolRelacion { get; set; }
}