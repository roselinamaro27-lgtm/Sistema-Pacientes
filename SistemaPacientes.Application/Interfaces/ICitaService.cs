using SistemaPacientes.Domain;

namespace SistemaPacientes.Application.Interfaces
{
	public interface ICitaService
	{
		Task<IEnumerable<Cita>> GetAllCitas();
		Task<Cita?> GetCitaById(int id);
		Task AddCita(Cita cita);
		Task UpdateCita(Cita cita);
		Task DeleteCita(int id);
	}
}