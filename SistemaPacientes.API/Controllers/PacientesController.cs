using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain.Entities;

namespace SistemaPacientes.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PacientesController : ControllerBase
	{
		private readonly IPacienteService _service;

		public PacientesController(IPacienteService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var pacientes = await _service.GetAllPacientes();
			return Ok(pacientes);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var paciente = await _service.GetPacienteById(id);

			if (paciente == null)
				return NotFound();

			return Ok(paciente);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Paciente paciente)
		{
			try
			{
				await _service.AddPaciente(paciente);

				return CreatedAtAction(
					nameof(GetById),
					new { id = paciente.Id },
					paciente
				);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Paciente paciente)
		{
			if (id != paciente.Id)
				return BadRequest("El ID no coincide.");

			try
			{
				await _service.UpdatePaciente(paciente);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _service.DeletePaciente(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}