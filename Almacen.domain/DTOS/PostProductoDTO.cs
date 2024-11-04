using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.domain.DTOS
{
	public class PostProductoDTO
	{
		public string? Nombre { get; set; }

		public string? Descripcion { get; set; }

		public string? Marca { get; set; }

		public double? Precio { get; set; }

		public int? Stock { get; set; }

		public bool? Activo { get; set; }
	}
}
