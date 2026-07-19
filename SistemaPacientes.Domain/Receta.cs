namespace SistemaPacientes.Domain;

public class Receta
{
	public int Id { get; set; }
	public int CitaId { get; set; }
	public string Instrucciones { get; set; }
	public DateTime FechaEmision { get; set; }
}