using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace datamodel.Models
{
    public partial class WebScrapContext : DbContext
    {
        public WebScrapContext()
        {
        }

        public WebScrapContext(DbContextOptions<WebScrapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WebScrap> WebScrap { get; set; }
        public virtual DbSet<WebScrapDetail> WebScrapDetail { get; set; }
        public virtual DbSet<WebScrapUrl> WebScrapUrl { get; set; }
        public virtual DbSet<Wselement> Wselement { get; set; }
        public virtual DbSet<Wsrun> Wsrun { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebScrap");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<WebScrap>(entity =>
            {
                entity.Property(e => e.DirUrl).IsUnicode(false);

                entity.Property(e => e.LoginUrl)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WebScrapDetail>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ElementName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ElementValue)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.WebScrapUrl)
                    .WithMany(p => p.WebScrapDetail)
                    .HasForeignKey(d => d.WebScrapUrlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebScrapDetail_WebScrapUrl");
            });

            modelBuilder.Entity<WebScrapUrl>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateScrapped).HasColumnType("datetime");

                entity.Property(e => e.WebScrapUrl1)
                    .IsRequired()
                    .HasColumnName("WebScrapUrl")
                    .IsUnicode(false);

                entity.HasOne(d => d.WebScrap)
                    .WithMany(p => p.WebScrapUrl)
                    .HasForeignKey(d => d.WebScrapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebScrapUrl_WebScrap");
            });

            modelBuilder.Entity<Wselement>(entity =>
            {
                entity.ToTable("WSElement");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ElementName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SearchBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StringToFind)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UrlLabel)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.WebScrap)
                    .WithMany(p => p.Wselement)
                    .HasForeignKey(d => d.WebScrapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WSElement_WebScrap");
            });

            modelBuilder.Entity<Wsrun>(entity =>
            {
                entity.ToTable("WSRun");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.WebScrap)
                    .WithMany(p => p.Wsrun)
                    .HasForeignKey(d => d.WebScrapId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WSRun_WebScrap");
            });
        }
    }
}
