using Microsoft.EntityFrameworkCore;
using TransformerFireApp.Models;

namespace TransformerFireApp.DBContext;

public partial class AppDBContext : DbContext
{
    public AppDBContext()
    {
    }

    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CalibrationValue> CalibrationValues { get; set; }

    public virtual DbSet<Sensor> Sensors { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlite("Data Source=C:\\VS2022Projects\\TransformerFireApp\\appdb.db");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source= C:\\Users\\liu_lihan\\source\\repos\\ProgrammingTrain\\appdb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalibrationValue>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("calibration_values");

            entity.HasIndex(e => e.ParamName, "IX_calibration_values_param_name").IsUnique();

            entity.Property(e => e.Index).HasColumnName("index");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.ParamName)
                .IsRequired()
                .HasColumnName("param_name");
            entity.Property(e => e.ParamValue).HasColumnName("param_value");
        });

        modelBuilder.Entity<Sensor>(entity =>
        {
            entity.ToTable("sensors");

            entity.HasIndex(e => e.Name, "IX_sensors_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discription).HasColumnName("discription");
            entity.Property(e => e.DisplayName)
                .IsRequired()
                .HasColumnName("display_name");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name");
            entity.Property(e => e.SignalType).HasColumnName("signal_type");
            entity.Property(e => e.SpanOutput)
                .IsRequired()
                .HasColumnType("NUMERIC")
                .HasColumnName("span_output");
            entity.Property(e => e.SpanSignal)
                .HasColumnType("NUMERIC")
                .HasColumnName("span_signal");
            entity.Property(e => e.Unit)
                .IsRequired()
                .HasColumnName("unit");
            entity.Property(e => e.ZeroOutput)
                .HasColumnType("NUMERIC")
                .HasColumnName("zero_output");
            entity.Property(e => e.ZeroSignal)
                .HasColumnType("NUMERIC")
                .HasColumnName("zero_signal");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
