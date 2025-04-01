using System.Reflection;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
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

            /* protected override void OnModelCreating(ModelBuilder modelBuilder)
             {
                 base.OnModelCreating(modelBuilder);

                 foreach (var entityType in Assembly.GetExecutingAssembly().GetTypes()
                                .Where(t => t.Namespace == "Api.Models" && t.IsClass && !t.IsAbstract))
                 {
                     modelBuilder.Entity(entityType);
                 }
             }
             */
        }
    }
}
