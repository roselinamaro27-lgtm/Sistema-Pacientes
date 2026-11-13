using SistemaPacientes.Domain;

namespace SistemaPacientes.Application.Interfaces
{
	public interface IRolService
	{
		Task<IEnumerable<Rol>> GetAllRoles();
		Task<Rol?> GetRolById(int id);
		Task AddRol(Rol rol);
		Task UpdateRol(Rol rol);
		Task DeleteRol(int id);
	}
}