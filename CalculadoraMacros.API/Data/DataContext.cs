using System;
using CalculadoraMacros.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CalculadoraMacros.API.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calculator> Calculator { get; set; }
        public virtual DbSet<CalculatorConfig> CalculatorConfig { get; set; }
        public virtual DbSet<Kpicolor> Kpicolor { get; set; }
        public virtual DbSet<MeasureDeviceType> MeasureDeviceType { get; set; }
        public virtual DbSet<Measurement> Measurement { get; set; }
        public virtual DbSet<MeasurementInput> MeasurementInput { get; set; }
        public virtual DbSet<MeasurementKpiresult> MeasurementKpiresult { get; set; }
        public virtual DbSet<Metric> Metric { get; set; }
        public virtual DbSet<MetricClass> MetricClass { get; set; }
        public virtual DbSet<MetricClassification> MetricClassification { get; set; }
        public virtual DbSet<MetricClassificationFactor> MetricClassificationFactor { get; set; }
        public virtual DbSet<MetricTable> MetricTable { get; set; }
        public virtual DbSet<UnitOfMeasure> UnitOfMeasure { get; set; }
        public virtual DbSet<User> User { get; set; }
protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Calculator>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<CalculatorConfig>(entity =>
            {
                entity.HasIndex(e => new { e.CalculatorId, e.MetricId })
                    .HasName("IX_CalculatorConfig_Code")
                    .IsUnique();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Calculator)
                    .WithMany(p => p.CalculatorConfig)
                    .HasForeignKey(d => d.CalculatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CalculatorConfig_Calculator");

                entity.HasOne(d => d.Metric)
                    .WithMany(p => p.CalculatorConfig)
                    .HasForeignKey(d => d.MetricId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CalculatorConfig_Metric");
            });

            modelBuilder.Entity<Kpicolor>(entity =>
            {
                entity.ToTable("KPIColor");

                entity.HasIndex(e => e.Code)
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MeasureDeviceType>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.Date })
                    .HasName("IX_Measurement_Code")
                    .IsUnique();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Calculator)
                    .WithMany(p => p.Measurement)
                    .HasForeignKey(d => d.CalculatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Measurement_Calculator");

                entity.HasOne(d => d.MeasureDeviceType)
                    .WithMany(p => p.Measurement)
                    .HasForeignKey(d => d.MeasureDeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Measurement_MeasureDeviceType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Measurement)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Measurement_User");
            });

            modelBuilder.Entity<MeasurementInput>(entity =>
            {
                entity.HasIndex(e => new { e.MeasurementId, e.MetricId })
                    .HasName("IX_MeasurementInput_Code")
                    .IsUnique();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Value).HasColumnType("money");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.MeasurementInput)
                    .HasForeignKey(d => d.MeasurementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasurementInput_Measurement");

                entity.HasOne(d => d.Metric)
                    .WithMany(p => p.MeasurementInput)
                    .HasForeignKey(d => d.MetricId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasurementInput_Metric");
            });

            modelBuilder.Entity<MeasurementKpiresult>(entity =>
            {
                entity.ToTable("MeasurementKPIResult");

                entity.HasIndex(e => new { e.MeasurementId, e.MetricId })
                    .HasName("IX_MeasurementKPIResult_Code")
                    .IsUnique();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GapValue).HasColumnType("money");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.ObjectiveValue).HasColumnType("money");

                entity.Property(e => e.KpiObjectiveValue).HasColumnType("money");

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Value).HasColumnType("money");
                entity.Property(e => e.KpiValue).HasColumnType("money");
                entity.Property(e => e.KpiGapValue).HasColumnType("money");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.MeasurementKpiresult)
                    .HasForeignKey(d => d.MeasurementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasurementKPIResult_Measurement");

                entity.HasOne(d => d.MetricClassification)
                    .WithMany(p => p.MeasurementKpiresult)
                    .HasForeignKey(d => d.MetricClassificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasurementKPIResult_MetricClassification");

                entity.HasOne(d => d.Metric)
                    .WithMany(p => p.MeasurementKpiresult)
                    .HasForeignKey(d => d.MetricId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MeasurementKPIResult_Metric");
            });

            modelBuilder.Entity<Metric>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.MaxValue).HasColumnType("money");

                entity.Property(e => e.MinValue).HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MetricClass)
                    .WithMany(p => p.Metric)
                    .HasForeignKey(d => d.MetricClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Metric_MetricClass");

                entity.HasOne(d => d.UnitOfMeasure)
                    .WithMany(p => p.Metric)
                    .HasForeignKey(d => d.UnitOfMeasureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Metric_UnitOfMeasure");
            });

            modelBuilder.Entity<MetricClass>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MetricClassification>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.KpiColor)
                    .WithMany(p => p.MetricClassification)
                    .HasForeignKey(d => d.KpiColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MetricClassification_KpiColor");

                entity.HasOne(d => d.MetricClass)
                    .WithMany(p => p.MetricClassification)
                    .HasForeignKey(d => d.MetricClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MetricClassification_MetricClass");
            });

            modelBuilder.Entity<MetricClassificationFactor>(entity =>
            {
                entity.HasIndex(e => new { e.MetricClassificationId, e.Name })
                    .HasName("IX_MetricClassificationFactor_Code")
                    .IsUnique();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Factor).HasColumnType("money");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MetricClassification)
                    .WithMany(p => p.MetricClassificationFactor)
                    .HasForeignKey(d => d.MetricClassificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MetricClassificationFactor_MetricClassification");
            });

            modelBuilder.Entity<MetricTable>(entity =>
            {
                entity.HasIndex(e => new { e.MetricId, e.MetricClassificationId })
                    .HasName("IX_MetricTable_Code")
                    .IsUnique();

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HiValue).HasColumnType("money");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.LowValue).HasColumnType("money");

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MetricClassification)
                    .WithMany(p => p.MetricTable)
                    .HasForeignKey(d => d.MetricClassificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MetricTable_MetricClassification");

                entity.HasOne(d => d.Metric)
                    .WithMany(p => p.MetricTable)
                    .HasForeignKey(d => d.MetricId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MetricTable_Metric");
            });

            modelBuilder.Entity<UnitOfMeasure>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Factor).HasColumnType("money");

                entity.Property(e => e.ImperialUmcode)
                    .IsRequired()
                    .HasColumnName("ImperialUMCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.MetricUmcode)
                    .IsRequired()
                    .HasColumnName("MetricUMCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HeightValue).HasColumnType("money");

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastMachine)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(host_name()))");

                entity.Property(e => e.LastUser)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(rtrim(suser_sname()))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.StatusFlag)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}
