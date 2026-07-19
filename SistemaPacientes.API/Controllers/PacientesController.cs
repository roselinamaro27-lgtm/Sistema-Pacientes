using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Domain.Entities;
using SistemaPacientes.Domain.Interfaces;

namespace SistemaPacientes.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PacientesController : ControllerBase
	{
		private readonly IPacienteRepository _repository;

		public PacientesController(IPacienteRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var pacientes = await _repository.GetAllAsync();
			return Ok(pacientes);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Paciente paciente)
		{
			await _repository.AddAsync(paciente);
			return Ok();
		}
	}
}