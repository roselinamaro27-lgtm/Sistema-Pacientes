using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultoriosController : ControllerBase
{
	private readonly IConsultorioRepository _repositorio;

	public ConsultoriosController(IConsultorioRepository repositorio)
	{
		_repositorio = repositorio;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Consultorio>>> Get()
	{
		return Ok(await _repositorio.GetAllAsync());
	}

	[HttpPost]
	public async Task<ActionResult> Post(Consultorio entidad)
	{
		await _repositorio.AddAsync(entidad);
		return Ok();
	}
}