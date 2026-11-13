using SistemaPacientes.Domain;

namespace SistemaPacientes.Application.Interfaces
{
	public interface IMedicamentoService
	{
		Task<IEnumerable<Medicamento>> GetAllMedicamentos();
		Task<Medicamento?> GetMedicamentoById(int id);
		Task AddMedicamento(Medicamento medicamento);
		Task UpdateMedicamento(Medicamento medicamento);
		Task DeleteMedicamento(int id);
	}
}