using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almacen.domain.DTOS
{
	public class PutProductoDTO:PostProductoDTO
	{
        public int Id { get; set; }
    }
}
