using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class TiposDocumento
{
    public string TipoDocumentoId { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();
}
