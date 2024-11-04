using System;
using System.Collections.Generic;

namespace Almacen.domain.Entities;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Marca { get; set; }

    public double? Precio { get; set; }

    public int? Stock { get; set; }

    public bool? Activo { get; set; }
}
