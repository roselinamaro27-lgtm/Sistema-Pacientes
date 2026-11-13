using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HistorialesMedicosController : ControllerBase
	{
		private readonly IHistorialMedicoService _service;

		public HistorialesMedicosController(IHistorialMedicoService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var historiales = await _service.GetAllHistoriales();
			return Ok(historiales);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var historial = await _service.GetHistorialById(id);

			if (historial == null)
				return NotFound();

			return Ok(historial);
		}

		[HttpPost]
		public async Task<IActionResult> Add(HistorialMedico historial)
		{
			try
			{
				await _service.AddHistorial(historial);

				return CreatedAtAction(
					nameof(GetById),
					new { id = historial.Id },
					historial
				);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, HistorialMedico historial)
		{
			if (id != historial.Id)
				return BadRequest("El ID no coincide.");

			try
			{
				await _service.UpdateHistorial(historial);
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
				await _service.DeleteHistorial(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}