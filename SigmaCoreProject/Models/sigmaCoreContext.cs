using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SigmaCoreProject.Models
{
    public partial class sigmaCoreContext : DbContext
    {
        public sigmaCoreContext(DbContextOptions<sigmaCoreContext> options) : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=sigmaCore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.DateComent).HasColumnType("datetime");

                entity.Property(e => e.IdUser).HasMaxLength(50);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.DateEndVisible).HasColumnType("datetime");

                entity.Property(e => e.DateStartVisible).HasColumnType("datetime");

                entity.Property(e => e.DateUpdate).HasColumnType("datetime");

                entity.Property(e => e.IdUserCreate).HasMaxLength(500);

                entity.Property(e => e.SeoDesc).HasMaxLength(500);

                entity.Property(e => e.SeoTitlte).HasMaxLength(500);

                entity.Property(e => e.ShoreInfo).HasMaxLength(500);

                entity.Property(e => e.TitleNews).HasMaxLength(500);
            });
        }
    }
}
