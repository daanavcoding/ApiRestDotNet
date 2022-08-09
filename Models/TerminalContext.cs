using Microsoft.EntityFrameworkCore;


namespace ApiRest.Models
{
    public partial class TerminalContext : DbContext
    {
        public TerminalContext()
        {
        }

        public TerminalContext(DbContextOptions<TerminalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Fabricantes> Fabricantes { get; set; }
        public virtual DbSet<Terminales> Terminales { get; set; }

        /// <summary>
        /// Conexión con la base de datos
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Terminal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.ToTable("Estado");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.EstadoDesc)
                    .IsUnicode(false)
                    .HasColumnName("estado_desc");

                entity.Property(e => e.EstadoName)
                    .IsUnicode(false)
                    .HasColumnName("estado_name");
            });

            modelBuilder.Entity<Fabricantes>(entity =>
            {
                entity.HasKey(e => e.IdFab);

                entity.Property(e => e.IdFab).HasColumnName("id_fab");

                entity.Property(e => e.FabDesc)
                    .IsUnicode(false)
                    .HasColumnName("fab_desc");

                entity.Property(e => e.FabName)
                    .IsUnicode(false)
                    .HasColumnName("fab_name");
            });

            modelBuilder.Entity<Terminales>(entity =>
            {
                entity.HasKey(e => e.IdTerminal);

                entity.Property(e => e.IdTerminal).HasColumnName("id_terminal");

                entity.Property(e => e.FechaEstado)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_estado");

                entity.Property(e => e.FechaFabricacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_fabricacion");

                entity.Property(e => e.IdEstado).HasColumnName("id_estado");

                entity.Property(e => e.IdFab).HasColumnName("id_fab");

                entity.Property(e => e.TerminalDesc)
                    .IsUnicode(false)
                    .HasColumnName("terminal_desc");

                entity.Property(e => e.TerminalName)
                    .IsUnicode(false)
                    .HasColumnName("terminal_name");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Terminales)
                    .HasForeignKey(d => d.IdEstado)
                    .HasConstraintName("FK_Terminales_Estado");

                entity.HasOne(d => d.IdFabNavigation)
                    .WithMany(p => p.Terminales)
                    .HasForeignKey(d => d.IdFab)
                    .HasConstraintName("FK_Terminales_Fabricantes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
