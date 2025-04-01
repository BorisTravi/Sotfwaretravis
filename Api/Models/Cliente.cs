using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Ruc { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? TipoCliente { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
}
