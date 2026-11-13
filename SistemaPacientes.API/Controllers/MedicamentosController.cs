using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MedicamentosController : ControllerBase
	{
		private readonly IMedicamentoService _service;

		public MedicamentosController(IMedicamentoService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var medicamentos = await _service.GetAllMedicamentos();
			return Ok(medicamentos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var medicamento = await _service.GetMedicamentoById(id);

			if (medicamento == null)
				return NotFound();

			return Ok(medicamento);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Medicamento medicamento)
		{
			try
			{
				await _service.AddMedicamento(medicamento);

				return CreatedAtAction(
					nameof(GetById),
					new { id = medicamento.Id },
					medicamento
				);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Medicamento medicamento)
		{
			if (id != medicamento.Id)
				return BadRequest("El ID no coincide.");

			try
			{
				await _service.UpdateMedicamento(medicamento);
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
				await _service.DeleteMedicamento(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}