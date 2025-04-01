using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Proveedore
{
    public int ProveedorId { get; set; }

    public string Ruc { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Contacto { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
