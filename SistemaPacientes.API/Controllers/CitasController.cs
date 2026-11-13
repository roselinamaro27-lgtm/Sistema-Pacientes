using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CitasController : ControllerBase
	{
		private readonly ICitaService _service;

		public CitasController(ICitaService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var citas = await _service.GetAllCitas();
			return Ok(citas);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var cita = await _service.GetCitaById(id);

			if (cita == null)
				return NotFound();

			return Ok(cita);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Cita cita)
		{
			try
			{
				await _service.AddCita(cita);

				return CreatedAtAction(
					nameof(GetById),
					new { id = cita.Id },
					cita
				);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Cita cita)
		{
			if (id != cita.Id)
				return BadRequest("El ID no coincide.");

			try
			{
				await _service.UpdateCita(cita);
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
				await _service.DeleteCita(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}