using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EspecialidadesController : ControllerBase
	{
		private readonly IEspecialidadService _service;

		public EspecialidadesController(IEspecialidadService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var especialidades = await _service.GetAllEspecialidades();
			return Ok(especialidades);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var especialidad = await _service.GetEspecialidadById(id);

			if (especialidad == null)
				return NotFound();

			return Ok(especialidad);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Especialidad especialidad)
		{
			try
			{
				await _service.AddEspecialidad(especialidad);

				return CreatedAtAction(
					nameof(GetById),
					new { id = especialidad.Id },
					especialidad
				);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Especialidad especialidad)
		{
			if (id != especialidad.Id)
				return BadRequest("El ID no coincide.");

			try
			{
				await _service.UpdateEspecialidad(especialidad);
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
				await _service.DeleteEspecialidad(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}