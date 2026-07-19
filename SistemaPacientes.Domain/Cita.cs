namespace SistemaPacientes.Domain;

public class Cita
{
	public int Id { get; set; }
	public DateTime Fecha { get; set; }
	public string Motivo { get; set; }
	public int PacienteId { get; set; }
	public int MedicoId { get; set; }
}