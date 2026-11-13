using Microsoft.AspNetCore.Mvc;
using SistemaPacientes.Application.Interfaces;
using SistemaPacientes.Domain;

namespace SistemaPacientes.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsuariosController : ControllerBase
	{
		private readonly IUsuarioService _service;

		public UsuariosController(IUsuarioService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var usuarios = await _service.GetAllUsuarios();
			return Ok(usuarios);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var usuario = await _service.GetUsuarioById(id);

			if (usuario == null)
				return NotFound();

			return Ok(usuario);
		}

		[HttpPost]
		public async Task<IActionResult> Add(Usuario usuario)
		{
			try
			{
				await _service.AddUsuario(usuario);

				return CreatedAtAction(
					nameof(GetById),
					new { id = usuario.Id },
					usuario
				);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, Usuario usuario)
		{
			if (id != usuario.Id)
				return BadRequest("El ID no coincide.");

			try
			{
				await _service.UpdateUsuario(usuario);
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
				await _service.DeleteUsuario(id);
				return NoContent();
			}
			catch (KeyNotFoundException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}