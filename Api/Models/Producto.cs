using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string NumeroParte { get; set; } = null!;

    public string? CodigoBarras { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal PrecioSinIgv { get; set; }

    public int? Stock { get; set; }

    public int? CategoriaId { get; set; }

    public int? ProveedorId { get; set; }

    public bool? AfectoIgv { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public bool? Activo { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; } = new List<DetalleComprobante>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();

    public virtual Proveedore? Proveedor { get; set; }

    public virtual ICollection<TipoMedidum> Medida { get; set; } = new List<TipoMedidum>();
}
