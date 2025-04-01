using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string? ApellidoPaternoUsuario { get; set; }

    public string? ApellidoMaternoUsuario { get; set; }

    public byte[] ContraseñaHash { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Rol { get; set; }

    public string? RucEmpresa { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? UltimoLogin { get; set; }

    public string? UltimoLoginIp { get; set; }

    public int? IntentosFallidos { get; set; }

    public DateTime? BloqueadoHasta { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Comprobante> Comprobantes { get; set; } = new List<Comprobante>();

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();

    public virtual Empresa? RucEmpresaNavigation { get; set; }
}
