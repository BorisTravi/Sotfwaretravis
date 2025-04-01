using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class DetalleComprobante
{
    public int DetalleId { get; set; }

    public int ComprobanteId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitarioSinIgv { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public virtual Comprobante Comprobante { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
