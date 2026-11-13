using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MedicosController : ControllerBase
	{
		private readonly IMedicoService _service;

		public MedicosController(IMedicoService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var medicos = await _service.GetAllMedicos();
			return Ok(medicos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var medico = await _service.GetMedicoById(id);

			if (medico == null)
				return NotFound();

			return Ok(medico);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Medico medico)
		{
			try
			{
				await _service.AddMedico(medico);

				return CreatedAtAction(
					nameof(GetById),
					new { id = medico.Id },
					medico
				);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Medico medico)
		{
			if (id != medico.Id)
				return BadRequest("El ID no coincide.");

			try
			{
				await _service.UpdateMedico(medico);
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
				await _service.DeleteMedico(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}