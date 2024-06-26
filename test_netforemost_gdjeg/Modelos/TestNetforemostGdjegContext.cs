using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace test_netforemost_gdjeg.Modelos;

public partial class TestNetforemostGdjegContext : DbContext
{
    public TestNetforemostGdjegContext()
    {
    }

    public TestNetforemostGdjegContext(DbContextOptions<TestNetforemostGdjegContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agente> Agentes { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<CuentasCliente> CuentasClientes { get; set; }

    public virtual DbSet<CuentasCobro> CuentasCobros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=test_netforemost_gdjeg;Integrated Security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agente>(entity =>
        {
            entity.HasKey(e => e.IdAgente).HasName("PK__agente__FAD2D3A619048F78");

            entity.ToTable("agente");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaAnulacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreAgente)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__clientes__D59466424B85FEB9");

            entity.ToTable("clientes");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaAnulacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CuentasCliente>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PK__cuentas___D41FD706D8FF65EF");

            entity.ToTable("cuentas_cliente");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.CuentasClientes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cuentas_c__IdCli__5BE2A6F2");
        });

        modelBuilder.Entity<CuentasCobro>(entity =>
        {
            entity.HasKey(e => e.IdCuentaCobro).HasName("PK__cuentas___9C7BC8087FC55F30");

            entity.ToTable("cuentas_cobro");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdAgenteNavigation).WithMany(p => p.CuentasCobros)
                .HasForeignKey(d => d.IdAgente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cuentas_c__IdAge__5CD6CB2B");

            entity.HasOne(d => d.IdCuentaClienteNavigation).WithMany(p => p.CuentasCobros)
                .HasForeignKey(d => d.IdCuentaCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cuentas_c__IdCue__5DCAEF64");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
