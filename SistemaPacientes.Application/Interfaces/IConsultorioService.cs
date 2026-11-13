using SistemaPacientes.Domain;

namespace SistemaPacientes.Application.Interfaces
{
	public interface IConsultorioService
	{
		Task<IEnumerable<Consultorio>> GetAllConsultorios();
		Task<Consultorio?> GetConsultorioById(int id);
		Task AddConsultorio(Consultorio consultorio);
		Task UpdateConsultorio(Consultorio consultorio);
		Task DeleteConsultorio(int id);
	}
}