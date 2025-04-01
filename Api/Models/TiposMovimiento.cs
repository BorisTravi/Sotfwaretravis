using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class TiposMovimiento
{
    public string TipoMovimientoId { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();
}
