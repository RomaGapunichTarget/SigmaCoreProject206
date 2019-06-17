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

        public virtual DbSet<PhysPers> PhysPers { get; set; }

        public virtual DbSet<Favorites> Favorites { get; set; }

        public virtual DbSet<RankNews> RankNews { get; set; }
        public virtual DbSet<S_TypeContent> STypeContent { get; set; }
        public virtual DbSet<OtherContent> OtherContent { get; set; }


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

            modelBuilder.Entity<PhysPers>(entity =>
            {
                entity.Property(e => e.DateDb).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.Patronymic).HasMaxLength(500);

                entity.Property(e => e.Surname).HasMaxLength(500);

                entity.Property(e => e.IdUser).HasMaxLength(500);
            });

            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.Property(e => e.IdUser).HasMaxLength(500);
            });

            modelBuilder.Entity<RankNews>(entity =>
            {
                entity.Property(e => e.IdUser).HasMaxLength(500);

                entity.Property(e => e.Rank).HasColumnType("decimal(5,2)");
            });

            modelBuilder.Entity<S_TypeContent>(entity =>
            {
                entity.Property(e => e.TypeConent).HasMaxLength(500);
            });

            modelBuilder.Entity<OtherContent>(entity =>
            {
                entity.Property(e => e.TitleContent).HasMaxLength(5000);
                entity.Property(e => e.IdUserCreate).HasMaxLength(50);
            });
        }
    }
}
