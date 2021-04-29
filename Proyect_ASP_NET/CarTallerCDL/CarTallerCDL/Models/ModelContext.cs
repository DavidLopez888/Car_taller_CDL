using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarTallerCDL
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<T01Item> T01Items { get; set; }
        public virtual DbSet<T02Tercero> T02Terceros { get; set; }
        public virtual DbSet<T03Vehiculo> T03Vehiculos { get; set; }
        public virtual DbSet<T041MovtoFactura> T041MovtoFacturas { get; set; }
        public virtual DbSet<T04Factura> T04Facturas { get; set; }
        public virtual DbSet<T05Mantenimiento> T05Mantenimientos { get; set; }
        public virtual DbSet<T06Descuento> T06Descuentos { get; set; }
        public virtual DbSet<T07Existenci> T07Existencis { get; set; }
        public virtual DbSet<T08Tiendum> T08Tienda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=172.16.45.62)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=DEVR11G)));Persist Security Info=True;User Id=CAR_CENTER_CDLC;Password=CDLC;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CAR_CENTER_CDLC");

            modelBuilder.Entity<T01Item>(entity =>
            {
                entity.HasKey(e => e.F01RowidItem)
                    .HasName("PK_T01");

                entity.ToTable("T01_ITEMS");

                entity.Property(e => e.F01RowidItem)
                    .HasPrecision(10)
                    .HasColumnName("F01_ROWID_ITEM");

                entity.Property(e => e.F01DescripionItem)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F01_DESCRIPION_ITEM");

                entity.Property(e => e.F01IdItem)
                    .HasPrecision(10)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F01_ID_ITEM");

                entity.Property(e => e.F01Notas)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F01_NOTAS");

                entity.Property(e => e.F01TipoItem)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F01_TIPO_ITEM")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<T02Tercero>(entity =>
            {
                entity.HasKey(e => e.F02RowidTercero);

                entity.ToTable("T02_TERCEROS");

                entity.Property(e => e.F02RowidTercero)
                    .HasPrecision(10)
                    .HasColumnName("F02_ROWID_TERCERO");

                entity.Property(e => e.F02Apellido1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_APELLIDO1");

                entity.Property(e => e.F02Apellido2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_APELLIDO2");

                entity.Property(e => e.F02Direccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_DIRECCION");

                entity.Property(e => e.F02Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_EMAIL");

                entity.Property(e => e.F02Estado)
                    .HasPrecision(5)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_ESTADO");

                entity.Property(e => e.F02IdDocumento)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_ID_DOCUMENTO")
                    .IsFixedLength(true);

                entity.Property(e => e.F02IndCliente)
                    .HasPrecision(5)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_IND_CLIENTE");

                entity.Property(e => e.F02IndEmpleado)
                    .HasPrecision(5)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_IND_EMPLEADO");

                entity.Property(e => e.F02Nit)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_NIT");

                entity.Property(e => e.F02Nombre1)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_NOMBRE1");

                entity.Property(e => e.F02Nombre2)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_NOMBRE2");

                entity.Property(e => e.F02Notas)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_NOTAS");

                entity.Property(e => e.F02RazonSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_RAZON_SOCIAL");

                entity.Property(e => e.F02Telfeono)
                    .HasPrecision(10)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_TELFEONO");

                entity.Property(e => e.F02TipoDocto)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_TIPO_DOCTO")
                    .IsFixedLength(true);

                entity.Property(e => e.F02VlrPresupuesto)
                    .HasColumnType("NUMBER(25,4)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F02_VLR_PRESUPUESTO");
            });

            modelBuilder.Entity<T03Vehiculo>(entity =>
            {
                entity.HasKey(e => e.F03RowidVehivulo)
                    .HasName("PK_T03");

                entity.ToTable("T03_VEHICULOS");

                entity.Property(e => e.F03RowidVehivulo)
                    .HasPrecision(10)
                    .HasColumnName("F03_ROWID_VEHIVULO");

                entity.Property(e => e.F03Descripcion)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("F03_DESCRIPCION");

                entity.Property(e => e.F03Notas)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("F03_NOTAS");

                entity.Property(e => e.F03Placa)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F03_PLACA")
                    .IsFixedLength(true);

                entity.Property(e => e.F03RowidTercero)
                    .HasPrecision(10)
                    .HasColumnName("F03_ROWID_TERCERO");

                entity.HasOne(d => d.F03RowidTerceroNavigation)
                    .WithMany(p => p.T03Vehiculos)
                    .HasForeignKey(d => d.F03RowidTercero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FL_T03_T02");
            });

            modelBuilder.Entity<T041MovtoFactura>(entity =>
            {
                entity.HasKey(e => e.F041RowidMovto)
                    .HasName("PK_T041");

                entity.ToTable("T041_MOVTO_FACTURA");

                entity.Property(e => e.F041RowidMovto)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("F041_ROWID_MOVTO");

                entity.Property(e => e.F041CantItem)
                    .HasColumnType("NUMBER(28,4)")
                    .HasColumnName("F041_CANT_ITEM");

                entity.Property(e => e.F041DescripionItem)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("F041_DESCRIPION_ITEM");

                entity.Property(e => e.F041IdItem)
                    .HasPrecision(10)
                    .HasColumnName("F041_ID_ITEM");

                entity.Property(e => e.F041Notas)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("F041_NOTAS");

                entity.Property(e => e.F041RowidDscto)
                    .HasPrecision(10)
                    .HasColumnName("F041_ROWID_DSCTO");

                entity.Property(e => e.F041RowidFactura)
                    .HasPrecision(10)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F041_ROWID_FACTURA");

                entity.Property(e => e.F041RowidItem)
                    .HasPrecision(10)
                    .HasColumnName("F041_ROWID_ITEM");

                entity.Property(e => e.F041RowidManto)
                    .HasPrecision(10)
                    .HasColumnName("F041_ROWID_MANTO");

                entity.Property(e => e.F041TipoItem)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("F041_TIPO_ITEM")
                    .IsFixedLength(true);

                entity.Property(e => e.F041VlrBruto)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F041_VLR_BRUTO");

                entity.Property(e => e.F041VlrDesto)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F041_VLR_DESTO");

                entity.Property(e => e.F041VlrImpto)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F041_VLR_IMPTO");

                entity.Property(e => e.F041VlrNeto)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F041_VLR_NETO");

                entity.HasOne(d => d.F041RowidDsctoNavigation)
                    .WithMany(p => p.T041MovtoFacturas)
                    .HasForeignKey(d => d.F041RowidDscto)
                    .HasConstraintName("FK_T041_T06");

                entity.HasOne(d => d.F041RowidFacturaNavigation)
                    .WithMany(p => p.T041MovtoFacturas)
                    .HasForeignKey(d => d.F041RowidFactura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T041_T04");

                entity.HasOne(d => d.F041RowidItemNavigation)
                    .WithMany(p => p.T041MovtoFacturas)
                    .HasForeignKey(d => d.F041RowidItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T041_T01");

                entity.HasOne(d => d.F041RowidMantoNavigation)
                    .WithMany(p => p.T041MovtoFacturas)
                    .HasForeignKey(d => d.F041RowidManto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T041_T05");
            });

            modelBuilder.Entity<T04Factura>(entity =>
            {
                entity.HasKey(e => e.F04RowidFactura)
                    .HasName("PK_T04");

                entity.ToTable("T04_FACTURAS");

                entity.Property(e => e.F04RowidFactura)
                    .HasPrecision(10)
                    .HasColumnName("F04_ROWID_FACTURA");

                entity.Property(e => e.F04ConsecDocto)
                    .HasPrecision(10)
                    .HasColumnName("F04_CONSEC_DOCTO");

                entity.Property(e => e.F04FechaDocto)
                    .HasColumnType("DATE")
                    .HasColumnName("F04_FECHA_DOCTO");

                entity.Property(e => e.F04Notas)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("F04_NOTAS");

                entity.Property(e => e.F04RazonSocialCliente)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("F04_RAZON_SOCIAL_CLIENTE");

                entity.Property(e => e.F04RazonSocialMecanico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("F04_RAZON_SOCIAL_MECANICO");

                entity.Property(e => e.F04RowidTerceroCliente)
                    .HasPrecision(10)
                    .HasColumnName("F04_ROWID_TERCERO_CLIENTE");

                entity.Property(e => e.F04RowidTerceroMecanico)
                    .HasPrecision(10)
                    .HasColumnName("F04_ROWID_TERCERO_MECANICO");

                entity.Property(e => e.F04RowidTienda)
                    .HasPrecision(10)
                    .HasColumnName("F04_ROWID_TIENDA");

                entity.Property(e => e.F04VlrBruto)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F04_VLR_BRUTO");

                entity.Property(e => e.F04VlrDesto)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F04_VLR_DESTO");

                entity.Property(e => e.F04VlrImpto)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F04_VLR_IMPTO");

                entity.Property(e => e.F04VlrNeto)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F04_VLR_NETO");

                entity.HasOne(d => d.F04RowidTerceroClienteNavigation)
                    .WithMany(p => p.T04FacturaF04RowidTerceroClienteNavigations)
                    .HasForeignKey(d => d.F04RowidTerceroCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T04_T02_1");

                entity.HasOne(d => d.F04RowidTerceroMecanicoNavigation)
                    .WithMany(p => p.T04FacturaF04RowidTerceroMecanicoNavigations)
                    .HasForeignKey(d => d.F04RowidTerceroMecanico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T04_T02_2");

                entity.HasOne(d => d.F04RowidTiendaNavigation)
                    .WithMany(p => p.T04Facturas)
                    .HasForeignKey(d => d.F04RowidTienda)
                    .HasConstraintName("FK_T04_T08");
            });

            modelBuilder.Entity<T05Mantenimiento>(entity =>
            {
                entity.HasKey(e => e.F05RowidManto)
                    .HasName("PK_T05");

                entity.ToTable("T05_MANTENIMIENTO");

                entity.Property(e => e.F05RowidManto)
                    .HasPrecision(10)
                    .HasColumnName("F05_ROWID_MANTO");

                entity.Property(e => e.F05EstadoManto)
                    .HasPrecision(5)
                    .HasColumnName("F05_ESTADO_MANTO");

                entity.Property(e => e.F05Foto)
                    .HasColumnType("LONG RAW")
                    .HasColumnName("F05_FOTO");

                entity.Property(e => e.F05IdMantto)
                    .HasPrecision(10)
                    .HasColumnName("F05_ID_MANTTO");

                entity.Property(e => e.F05Notas)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("F05_NOTAS");

                entity.Property(e => e.F05RowidTerceroCliente)
                    .HasPrecision(10)
                    .HasColumnName("F05_ROWID_TERCERO_CLIENTE");

                entity.Property(e => e.F05RowidVehiculo)
                    .HasPrecision(10)
                    .HasColumnName("F05_ROWID_VEHICULO");

                entity.Property(e => e.F05VlrMax)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F05_VLR_MAX");

                entity.Property(e => e.F05VlrMin)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F05_VLR_MIN");

                entity.HasOne(d => d.F05RowidTerceroClienteNavigation)
                    .WithMany(p => p.T05Mantenimientos)
                    .HasForeignKey(d => d.F05RowidTerceroCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T05_T02");

                entity.HasOne(d => d.F05RowidVehiculoNavigation)
                    .WithMany(p => p.T05Mantenimientos)
                    .HasForeignKey(d => d.F05RowidVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T05_T03");
            });

            modelBuilder.Entity<T06Descuento>(entity =>
            {
                entity.HasKey(e => e.F06RowidDescto)
                    .HasName("PK_T06");

                entity.ToTable("T06_DESCUENTOS");

                entity.Property(e => e.F06RowidDescto)
                    .HasPrecision(10)
                    .HasColumnName("F06_ROWID_DESCTO");

                entity.Property(e => e.F06Estado)
                    .HasPrecision(5)
                    .HasColumnName("F06_ESTADO");

                entity.Property(e => e.F06RowidItem)
                    .HasPrecision(10)
                    .HasColumnName("F06_ROWID_ITEM");

                entity.Property(e => e.F06RowidTerceroCliente)
                    .HasPrecision(10)
                    .HasColumnName("F06_ROWID_TERCERO_CLIENTE");

                entity.Property(e => e.F06VlrMax)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F06_VLR_MAX");

                entity.Property(e => e.F06VlrMin)
                    .HasColumnType("NUMBER(25,4)")
                    .HasColumnName("F06_VLR_MIN");

                entity.HasOne(d => d.F06RowidItemNavigation)
                    .WithMany(p => p.T06Descuentos)
                    .HasForeignKey(d => d.F06RowidItem)
                    .HasConstraintName("FK_T06_T01");

                entity.HasOne(d => d.F06RowidTerceroClienteNavigation)
                    .WithMany(p => p.T06Descuentos)
                    .HasForeignKey(d => d.F06RowidTerceroCliente)
                    .HasConstraintName("FK_T06_T02");
            });

            modelBuilder.Entity<T07Existenci>(entity =>
            {
                entity.HasKey(e => e.F07RowidItem)
                    .HasName("PK_T07");

                entity.ToTable("T07_EXISTENCIS");

                entity.Property(e => e.F07RowidItem)
                    .HasPrecision(10)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("F07_ROWID_ITEM");

                entity.Property(e => e.F07CantExistencia)
                    .HasColumnType("NUMBER(28,4)")
                    .HasColumnName("F07_CANT_EXISTENCIA");

                entity.Property(e => e.F07RowidTienda)
                    .HasPrecision(10)
                    .HasColumnName("F07_ROWID_TIENDA");

                entity.HasOne(d => d.F07RowidItemNavigation)
                    .WithOne(p => p.T07Existenci)
                    .HasForeignKey<T07Existenci>(d => d.F07RowidItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T07_T01");

                entity.HasOne(d => d.F07RowidTiendaNavigation)
                    .WithMany(p => p.T07Existencis)
                    .HasForeignKey(d => d.F07RowidTienda)
                    .HasConstraintName("FK_T07_T08");
            });

            modelBuilder.Entity<T08Tiendum>(entity =>
            {
                entity.HasKey(e => e.F08RowidTienda)
                    .HasName("PK_T08");

                entity.ToTable("T08_TIENDA");

                entity.Property(e => e.F08RowidTienda)
                    .HasPrecision(10)
                    .HasColumnName("F08_ROWID_TIENDA");

                entity.Property(e => e.F08Ciudad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("F08_CIUDAD");

                entity.Property(e => e.F08NombreTienda)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("F08_NOMBRE_TIENDA");
            });

            modelBuilder.HasSequence("SQ_F01_ROWID_ITEM");

            modelBuilder.HasSequence("SQ_F02_ROWID_TERCERO");

            modelBuilder.HasSequence("SQ_F03_ROWID_VEHIVULO");

            modelBuilder.HasSequence("SQ_F04_ROWID_FACTURA");

            modelBuilder.HasSequence("SQ_F041_ROWID_FACTURA");

            modelBuilder.HasSequence("SQ_F05_ROWID_MANTO");

            modelBuilder.HasSequence("SQ_F06_ROWID_DESCTO");

            modelBuilder.HasSequence("SQ_F07_ROWID_ITEM");

            modelBuilder.HasSequence("SQ_F08_ROWID_TIENDA");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
