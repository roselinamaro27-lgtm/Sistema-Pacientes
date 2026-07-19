using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicosController : ControllerBase
{
	private readonly IMedicoRepository _repositorio;

	public MedicosController(IMedicoRepository repositorio)
	{
		_repositorio = repositorio;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Medico>>> Get()
	{
		return Ok(await _repositorio.GetAllAsync());
	}

	[HttpPost]
	public async Task<ActionResult> Post(Medico entidad)
	{
		await _repositorio.AddAsync(entidad);
		return Ok();
	}
}