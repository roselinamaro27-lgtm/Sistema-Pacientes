using SistemaPacientes.Domain;

namespace SistemaPacientes.Application.Interfaces
{
	public interface IEspecialidadService
	{
		Task<IEnumerable<Especialidad>> GetAllEspecialidades();
		Task<Especialidad?> GetEspecialidadById(int id);
		Task AddEspecialidad(Especialidad especialidad);
		Task UpdateEspecialidad(Especialidad especialidad);
		Task DeleteEspecialidad(int id);
	}
}