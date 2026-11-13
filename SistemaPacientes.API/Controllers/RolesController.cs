using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RolesController : ControllerBase
	{
		private readonly IRolService _service;

		public RolesController(IRolService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var roles = await _service.GetAllRoles();
			return Ok(roles);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var rol = await _service.GetRolById(id);

			if (rol == null)
				return NotFound();

			return Ok(rol);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Rol rol)
		{
			try
			{
				await _service.AddRol(rol);

				return CreatedAtAction(
					nameof(GetById),
					new { id = rol.Id },
					rol
				);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Rol rol)
		{
			if (id != rol.Id)
				return BadRequest("El ID no coincide.");

			try
			{
				await _service.UpdateRol(rol);
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
				await _service.DeleteRol(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}