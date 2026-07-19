using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
	private readonly IUsuarioRepository _repositorio;

	public UsuariosController(IUsuarioRepository repositorio)
	{
		_repositorio = repositorio;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Usuario>>> Get()
	{
		return Ok(await _repositorio.GetAllAsync());
	}

	[HttpPost]
	public async Task<ActionResult> Post(Usuario entidad)
	{
		await _repositorio.AddAsync(entidad);
		return Ok();
	}
}