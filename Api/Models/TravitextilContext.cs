using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public partial class TravitextilContext : DbContext
{
    public TravitextilContext()
    {
    }

    public TravitextilContext(DbContextOptions<TravitextilContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Comprobante> Comprobantes { get; set; }

    public virtual DbSet<DetalleComprobante> DetalleComprobantes { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<MovimientosInventario> MovimientosInventarios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<TipoMedidum> TipoMedida { get; set; }

    public virtual DbSet<TiposDocumento> TiposDocumentos { get; set; }

    public virtual DbSet<TiposMovimiento> TiposMovimientos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LocalHost;Database=TRAVITEXTIL;User Id=SA;Password=ACDS3Zi#8;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__categori__DB875A4F9E34B8FE");

            entity.ToTable("categorias");

            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.CodigoSunat)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("codigo_sunat");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__clientes__47E34D64DB6E8507");

            entity.ToTable("clientes");

            entity.HasIndex(e => e.Ruc, "UQ__clientes__C2B74E6174C7EDF5").IsUnique();

            entity.HasIndex(e => e.Ruc, "idx_clientes_ruc");

            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("ACTIVO")
                .HasColumnName("estado");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("razon_social");
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("persona_juridica")
                .HasColumnName("tipo_cliente");
        });

        modelBuilder.Entity<Comprobante>(entity =>
        {
            entity.HasKey(e => e.ComprobanteId).HasName("PK__comproba__F0206326295C0FD9");

            entity.ToTable("comprobantes");

            entity.HasIndex(e => e.SerieNumero, "UQ__comproba__2D8B6991F12F1245").IsUnique();

            entity.HasIndex(e => e.SerieNumero, "idx_comprobantes_serie");

            entity.Property(e => e.ComprobanteId).HasColumnName("comprobante_id");
            entity.Property(e => e.Cdv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cdv");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.CodigoHash)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codigo_hash");
            entity.Property(e => e.EnlacePdf)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("enlace_pdf");
            entity.Property(e => e.EnlaceXml)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("enlace_xml");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("BORRADOR")
                .HasColumnName("estado");
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("fecha_emision");
            entity.Property(e => e.FechaVencimiento).HasColumnName("fecha_vencimiento");
            entity.Property(e => e.Igv)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("igv");
            entity.Property(e => e.Moneda)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("PEN")
                .HasColumnName("moneda");
            entity.Property(e => e.SerieNumero)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("serie_numero");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.TipoComprobante)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_comprobante");
            entity.Property(e => e.TipoDocumentoId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo_documento_id");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__comproban__clien__6D0D32F4");

            entity.HasOne(d => d.TipoDocumento).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.TipoDocumentoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comprobantes_tipos_documento");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Comprobantes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__comproban__usuar__1CBC4616");
        });

        modelBuilder.Entity<DetalleComprobante>(entity =>
        {
            entity.HasKey(e => e.DetalleId).HasName("PK__detalle___91B12E709E88270B");

            entity.ToTable("detalle_comprobante");

            entity.Property(e => e.DetalleId).HasColumnName("detalle_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.ComprobanteId).HasColumnName("comprobante_id");
            entity.Property(e => e.Igv)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("igv");
            entity.Property(e => e.PrecioUnitarioSinIgv)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio_unitario_sin_igv");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.Comprobante).WithMany(p => p.DetalleComprobantes)
                .HasForeignKey(d => d.ComprobanteId)
                .HasConstraintName("FK__detalle_c__compr__75A278F5");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleComprobantes)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__detalle_c__produ__76969D2E");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Ruc).HasName("PK__empresas__C2B74E60E5F8BB6D");

            entity.ToTable("empresas");

            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("razon_social");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<MovimientosInventario>(entity =>
        {
            entity.HasKey(e => e.MovimientoId).HasName("PK__tmp_ms_x__A87EF0E57ADF260C");

            entity.ToTable("movimientos_inventario");

            entity.HasIndex(e => e.ProductoId, "idx_movimientos_producto");

            entity.Property(e => e.MovimientoId).HasColumnName("movimiento_id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.DocumentoRelacionado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documento_relacionado");
            entity.Property(e => e.FechaMovimiento)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("fecha_movimiento");
            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.TipoMovimientoId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo_movimiento_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Producto).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__movimient__produ__09A971A2");

            entity.HasOne(d => d.TipoMovimiento).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.TipoMovimientoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tipos_movimiento");

            entity.HasOne(d => d.Usuario).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__movimient__usuar__1DB06A4F");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__producto__FB5CEEEC936E59E3");

            entity.ToTable("productos");

            entity.HasIndex(e => e.NumeroParte, "UQ__producto__0E8B8B766333896A").IsUnique();

            entity.HasIndex(e => e.NumeroParte, "idx_productos_parte");

            entity.Property(e => e.ProductoId).HasColumnName("producto_id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.AfectoIgv)
                .HasDefaultValue(true)
                .HasColumnName("afecto_igv");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.CodigoBarras)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codigo_barras");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumeroParte)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numero_parte");
            entity.Property(e => e.PrecioSinIgv)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("precio_sin_igv");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Stock)
                .HasDefaultValue(0)
                .HasColumnName("stock");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__productos__categ__5535A963");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__productos__prove__5629CD9C");

            entity.HasMany(d => d.Medida).WithMany(p => p.Productos)
                .UsingEntity<Dictionary<string, object>>(
                    "DetalleTipoMedidum",
                    r => r.HasOne<TipoMedidum>().WithMany()
                        .HasForeignKey("MedidaId")
                        .HasConstraintName("FK__detalle_t__medid__59FA5E80"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("ProductoId")
                        .HasConstraintName("FK__detalle_t__produ__59063A47"),
                    j =>
                    {
                        j.HasKey("ProductoId", "MedidaId").HasName("PK__detalle___A25E5018FC7E938B");
                        j.ToTable("detalle_tipo_medida");
                        j.IndexerProperty<int>("ProductoId").HasColumnName("producto_id");
                        j.IndexerProperty<int>("MedidaId").HasColumnName("medida_id");
                    });
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__proveedo__88BBADA45F7552CE");

            entity.ToTable("proveedores");

            entity.HasIndex(e => e.Ruc, "UQ__proveedo__C2B74E6149D2CA76").IsUnique();

            entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("ACTIVO")
                .HasColumnName("estado");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("razon_social");
            entity.Property(e => e.Ruc)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TipoMedidum>(entity =>
        {
            entity.HasKey(e => e.MedidaId).HasName("PK__tipo_med__902BEF441B2D3915");

            entity.ToTable("tipo_medida");

            entity.HasIndex(e => e.Nombre, "UQ__tipo_med__72AFBCC69DC05389").IsUnique();

            entity.Property(e => e.MedidaId).HasColumnName("medida_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TiposDocumento>(entity =>
        {
            entity.HasKey(e => e.TipoDocumentoId).HasName("PK__tipos_do__5CFA6007D4A41CFE");

            entity.ToTable("tipos_documento");

            entity.Property(e => e.TipoDocumentoId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo_documento_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TiposMovimiento>(entity =>
        {
            entity.HasKey(e => e.TipoMovimientoId).HasName("PK__tipos_mo__ABEA6413F8989645");

            entity.ToTable("tipos_movimiento");

            entity.Property(e => e.TipoMovimientoId)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tipo_movimiento_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__tmp_ms_x__2ED7D2AF7FCF0B05");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Email, "UQ__tmp_ms_x__AB6E6164B6540E99").IsUnique();

            entity.HasIndex(e => e.NombreUsuario, "UQ__tmp_ms_x__D4D22D746F912B76").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.ApellidoMaternoUsuario)
                .HasMaxLength(50)
                .HasColumnName("apellido_materno_usuario");
            entity.Property(e => e.ApellidoPaternoUsuario)
                .HasMaxLength(50)
                .HasColumnName("apellido_paterno_usuario");
            entity.Property(e => e.BloqueadoHasta).HasColumnName("bloqueado_hasta");
            entity.Property(e => e.ContraseñaHash)
                .HasMaxLength(256)
                .HasColumnName("contraseña_hash");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IntentosFallidos)
                .HasDefaultValue(0)
                .HasColumnName("intentos_fallidos");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_usuario");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("ventas")
                .HasColumnName("rol");
            entity.Property(e => e.RucEmpresa)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ruc_empresa");
            entity.Property(e => e.Salt)
                .HasMaxLength(128)
                .HasColumnName("salt");
            entity.Property(e => e.UltimoLogin).HasColumnName("ultimo_login");
            entity.Property(e => e.UltimoLoginIp)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ultimo_login_ip");

            entity.HasOne(d => d.RucEmpresaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RucEmpresa)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__usuarios__ruc_em__1BC821DD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
