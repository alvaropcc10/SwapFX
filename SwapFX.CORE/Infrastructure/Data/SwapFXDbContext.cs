using Microsoft.EntityFrameworkCore;
using SwapFX.CORE.Core.Entities;
namespace SwapFX.CORE.Infrastructure.Data;
public partial class SwapFXDbContext : DbContext
{
    public SwapFXDbContext() { }
    public SwapFXDbContext(DbContextOptions<SwapFXDbContext> options) : base(options) { }
    public virtual DbSet<Usuario> Usuario { get; set; }
    public virtual DbSet<Moneda> Moneda { get; set; }
    public virtual DbSet<CuentaBancaria> CuentaBancaria { get; set; }
    public virtual DbSet<Oferta> Oferta { get; set; }
    public virtual DbSet<Transaccion> Transaccion { get; set; }
    public virtual DbSet<EstadoTransaccion> EstadoTransaccion { get; set; }
    public virtual DbSet<Comprobante> Comprobante { get; set; }
    public virtual DbSet<Calificacion> Calificacion { get; set; }
    public virtual DbSet<Disputa> Disputa { get; set; }
    public virtual DbSet<DocumentoIdentidad> DocumentoIdentidad { get; set; }
    public virtual DbSet<Notificacion> Notificacion { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity => {
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Dni).HasMaxLength(20);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Password).HasMaxLength(200);
            entity.Property(e => e.Tipo).HasMaxLength(1).IsUnicode(false).IsFixedLength();
            entity.Property(e => e.FechaRegistro).HasColumnType("date");
        });
        modelBuilder.Entity<Moneda>(entity => {
            entity.Property(e => e.Codigo).HasMaxLength(3);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Simbolo).HasMaxLength(5);
        });
        modelBuilder.Entity<CuentaBancaria>(entity => {
            entity.Property(e => e.Banco).HasMaxLength(100);
            entity.Property(e => e.Titular).HasMaxLength(150);
            entity.Property(e => e.TipoCuenta).HasMaxLength(50);
            entity.Property(e => e.NumeroCuenta).HasMaxLength(30);
            entity.Property(e => e.Cci).HasMaxLength(30);
            entity.Property(e => e.Moneda).HasMaxLength(3);
            entity.HasOne(d => d.Usuario).WithMany(p => p.CuentasBancarias).HasForeignKey(d => d.UsuarioId).HasConstraintName("FK_CuentaBancaria_Usuario");
        });
        modelBuilder.Entity<Oferta>(entity => {
            entity.Property(e => e.Tipo).HasMaxLength(1).IsUnicode(false).IsFixedLength();
            entity.Property(e => e.Monto).HasColumnType("decimal(18,2)");
            entity.Property(e => e.TipoCambio).HasColumnType("decimal(18,4)");
            entity.Property(e => e.Estado).HasMaxLength(30);
            entity.Property(e => e.Notas).HasMaxLength(500);
            entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");
            entity.Property(e => e.FechaExpiracion).HasColumnType("datetime");
            entity.HasOne(d => d.Usuario).WithMany(p => p.Ofertas).HasForeignKey(d => d.UsuarioId).HasConstraintName("FK_Oferta_Usuario");
            entity.HasOne(d => d.MonedaOrigen).WithMany(p => p.OfertasOrigen).HasForeignKey(d => d.MonedaOrigenId).HasConstraintName("FK_Oferta_MonedaOrigen");
            entity.HasOne(d => d.MonedaDestino).WithMany(p => p.OfertasDestino).HasForeignKey(d => d.MonedaDestinoId).HasConstraintName("FK_Oferta_MonedaDestino");
        });
        modelBuilder.Entity<Transaccion>(entity => {
            entity.Property(e => e.Codigo).HasMaxLength(20);
            entity.Property(e => e.MontoOrigen).HasColumnType("decimal(18,2)");
            entity.Property(e => e.MontoDestino).HasColumnType("decimal(18,2)");
            entity.Property(e => e.TipoCambioAplicado).HasColumnType("decimal(18,4)");
            entity.Property(e => e.EstadoActual).HasMaxLength(30);
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.FechaFinalizacion).HasColumnType("datetime");
            entity.HasOne(d => d.OfertaCompra).WithMany(p => p.TransaccionesCompra).HasForeignKey(d => d.OfertaCompraId).HasConstraintName("FK_Transaccion_OfertaCompra");
            entity.HasOne(d => d.OfertaVenta).WithMany(p => p.TransaccionesVenta).HasForeignKey(d => d.OfertaVentaId).HasConstraintName("FK_Transaccion_OfertaVenta");
            entity.HasOne(d => d.Comprador).WithMany().HasForeignKey(d => d.CompradorId).HasConstraintName("FK_Transaccion_Comprador");
            entity.HasOne(d => d.Vendedor).WithMany().HasForeignKey(d => d.VendedorId).HasConstraintName("FK_Transaccion_Vendedor");
        });
        modelBuilder.Entity<EstadoTransaccion>(entity => {
            entity.Property(e => e.Estado).HasMaxLength(30);
            entity.Property(e => e.FechaCambio).HasColumnType("datetime");
            entity.Property(e => e.Comentario).HasMaxLength(500);
            entity.HasOne(d => d.Transaccion).WithMany(p => p.Estados).HasForeignKey(d => d.TransaccionId).HasConstraintName("FK_EstadoTransaccion_Transaccion");
        });
        modelBuilder.Entity<Comprobante>(entity => {
            entity.Property(e => e.NombreArchivo).HasMaxLength(200);
            entity.Property(e => e.RutaArchivo).HasMaxLength(500);
            entity.Property(e => e.FormatoArchivo).HasMaxLength(10);
            entity.Property(e => e.NumeroOperacion).HasMaxLength(50);
            entity.Property(e => e.FechaTransferencia).HasColumnType("datetime");
            entity.Property(e => e.FechaSubida).HasColumnType("datetime");
            entity.HasOne(d => d.Transaccion).WithMany(p => p.Comprobantes).HasForeignKey(d => d.TransaccionId).HasConstraintName("FK_Comprobante_Transaccion");
        });
        modelBuilder.Entity<Calificacion>(entity => {
            entity.Property(e => e.Comentario).HasMaxLength(280);
            entity.Property(e => e.FechaCalificacion).HasColumnType("datetime");
            entity.HasOne(d => d.Transaccion).WithMany(p => p.Calificaciones).HasForeignKey(d => d.TransaccionId).HasConstraintName("FK_Calificacion_Transaccion");
            entity.HasOne(d => d.UsuarioCalificador).WithMany(p => p.CalificacionesDadas).HasForeignKey(d => d.UsuarioCalificadorId).HasConstraintName("FK_Calificacion_Calificador");
            entity.HasOne(d => d.UsuarioCalificado).WithMany(p => p.CalificacionesRecibidas).HasForeignKey(d => d.UsuarioCalificadoId).HasConstraintName("FK_Calificacion_Calificado");
        });
        modelBuilder.Entity<Disputa>(entity => {
            entity.Property(e => e.Motivo).HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.Estado).HasMaxLength(30);
            entity.Property(e => e.Resolucion).HasMaxLength(1000);
            entity.Property(e => e.FechaReporte).HasColumnType("datetime");
            entity.Property(e => e.FechaResolucion).HasColumnType("datetime");
            entity.HasOne(d => d.Transaccion).WithMany(p => p.Disputas).HasForeignKey(d => d.TransaccionId).HasConstraintName("FK_Disputa_Transaccion");
        });
        modelBuilder.Entity<DocumentoIdentidad>(entity => {
            entity.Property(e => e.TipoDoc).HasMaxLength(20);
            entity.Property(e => e.NumeroDoc).HasMaxLength(20);
            entity.Property(e => e.RutaArchivo).HasMaxLength(500);
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.Observacion).HasMaxLength(500);
            entity.Property(e => e.FechaSubida).HasColumnType("datetime");
            entity.Property(e => e.FechaRevision).HasColumnType("datetime");
            entity.HasOne(d => d.Usuario).WithMany().HasForeignKey(d => d.UsuarioId).HasConstraintName("FK_DocumentoIdentidad_Usuario");
        });
        modelBuilder.Entity<Notificacion>(entity => {
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.Mensaje).HasMaxLength(500);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.HasOne(d => d.Usuario).WithMany().HasForeignKey(d => d.UsuarioId).HasConstraintName("FK_Notificacion_Usuario");
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
