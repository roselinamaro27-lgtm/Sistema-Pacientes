using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Domain.Entities
{
	public class Paciente
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public string Apellido { get; set; } = string.Empty;
		public string Cedula { get; set; } = string.Empty;
		public DateTime FechaNacimiento { get; set; }
		public string Telefono { get; set; } = string.Empty;
		public string Direccion { get; set; } = string.Empty;
	}
}