using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ConsultoriosController : ControllerBase
	{
		private readonly IConsultorioService _service;

		public ConsultoriosController(IConsultorioService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var consultorios = await _service.GetAllConsultorios();
			return Ok(consultorios);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var consultorio = await _service.GetConsultorioById(id);

			if (consultorio == null)
				return NotFound();

			return Ok(consultorio);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Consultorio consultorio)
		{
			try
			{
				await _service.AddConsultorio(consultorio);

				return CreatedAtAction(
					nameof(GetById),
					new { id = consultorio.Id },
					consultorio
				);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Consultorio consultorio)
		{
			if (id != consultorio.Id)
				return BadRequest("El ID no coincide.");

			try
			{
				await _service.UpdateConsultorio(consultorio);
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
				await _service.DeleteConsultorio(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}