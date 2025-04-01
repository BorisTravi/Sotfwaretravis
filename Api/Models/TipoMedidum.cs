using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class TipoMedidum
{
    public int MedidaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
