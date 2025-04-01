using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Empresa
{
    public string Ruc { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
