using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RecetasController : ControllerBase
	{
		private readonly IRecetaService _service;
		public RecetasController(IRecetaService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var recetas = await _service.GetAllRecetas();
			return Ok(recetas);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var receta = await _service.GetRecetaById(id);

			if (receta == null)
				return NotFound();

			return Ok(receta);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Receta receta)
		{
			try
			{
				await _service.AddReceta(receta);

				return CreatedAtAction(
					nameof(GetById),
					new { id = receta.Id },
					receta
				);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Receta receta)
		{
			if (id != receta.Id)
				return BadRequest("El ID no coincide.");

			try
			{
				await _service.UpdateReceta(receta);
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
				await _service.DeleteReceta(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}