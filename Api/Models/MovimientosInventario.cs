using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class MovimientosInventario
{
    public int MovimientoId { get; set; }

    public int ProductoId { get; set; }

    public int UsuarioId { get; set; }

    public string TipoMovimientoId { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateTime? FechaMovimiento { get; set; }

    public string? DocumentoRelacionado { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual TiposMovimiento TipoMovimiento { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
