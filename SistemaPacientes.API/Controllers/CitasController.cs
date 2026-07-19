using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitasController : ControllerBase
{
	private readonly ICitaRepository _repositorio;

	public CitasController(ICitaRepository repositorio)
	{
		_repositorio = repositorio;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Cita>>> Get()
	{
		return Ok(await _repositorio.GetAllAsync());
	}

	[HttpPost]
	public async Task<ActionResult> Post(Cita entidad)
	{
		await _repositorio.AddAsync(entidad);
		return Ok();
	}
}