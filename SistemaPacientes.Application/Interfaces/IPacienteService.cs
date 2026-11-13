
using SistemaPacientes.Domain.Entities;

namespace SistemaPacientes.Application.Interfaces
{
	public interface IPacienteService
	{
		Task<IEnumerable<Paciente>> GetAllPacientes();
		Task<Paciente?> GetPacienteById(int id);
		Task AddPaciente(Paciente paciente);
		Task UpdatePaciente(Paciente paciente);
		Task DeletePaciente(int id);
	}
}
