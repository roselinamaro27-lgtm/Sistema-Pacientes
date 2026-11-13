using SistemaPacientes.Domain;

namespace SistemaPacientes.Application.Interfaces
{
	public interface IMedicoService
	{
		Task<IEnumerable<Medico>> GetAllMedicos();
		Task<Medico?> GetMedicoById(int id);
		Task AddMedico(Medico medico);
		Task UpdateMedico(Medico medico);
		Task DeleteMedico(int id);
	}
}