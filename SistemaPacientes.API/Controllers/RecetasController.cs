using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecetasController : ControllerBase
{
	private readonly IRecetaRepository _repositorio;

	public RecetasController(IRecetaRepository repositorio)
	{
		_repositorio = repositorio;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Receta>>> Get()
	{
		return Ok(await _repositorio.GetAllAsync());
	}

	[HttpPost]
	public async Task<ActionResult> Post(Receta entidad)
	{
		await _repositorio.AddAsync(entidad);
		return Ok();
	}
}