using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Domain.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HistorialesMedicosController : ControllerBase
{
	private readonly IHistorialMedicoRepository _repositorio;

	public HistorialesMedicosController(IHistorialMedicoRepository repositorio)
	{
		_repositorio = repositorio;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<HistorialMedico>>> Get()
	{
		return Ok(await _repositorio.GetAllAsync());
	}

	[HttpPost]
	public async Task<ActionResult> Post(HistorialMedico entidad)
	{
		await _repositorio.AddAsync(entidad);
		return Ok();
	}
}