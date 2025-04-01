using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Comprobante
{
    public int ComprobanteId { get; set; }

    public int ClienteId { get; set; }

    public int UsuarioId { get; set; }

    public string TipoComprobante { get; set; } = null!;

    public string SerieNumero { get; set; } = null!;

    public DateTime FechaEmision { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public string? Moneda { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public string? CodigoHash { get; set; }

    public string? Cdv { get; set; }

    public string? EnlacePdf { get; set; }

    public string? EnlaceXml { get; set; }

    public string? Estado { get; set; }

    public string TipoDocumentoId { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; } = new List<DetalleComprobante>();

    public virtual TiposDocumento TipoDocumento { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
