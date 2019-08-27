using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DwellAPI.Model
{
    public partial class DwellAPIContext : DbContext
    {
        public DwellAPIContext()
        {
        }

        public DwellAPIContext(DbContextOptions<DwellAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Routines> Routines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:darjeeling.database.windows.net,1433;Initial Catalog=Dwelling;Persist Security Info=False;User ID=TeaAdmin;Password=Coolduder1ng;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.ItemName).IsUnicode(false);

                entity.Property(e => e.Room).IsUnicode(false);

                entity.Property(e => e.Tags).IsUnicode(false);
            });

            modelBuilder.Entity<Routines>(entity =>
            {
                entity.Property(e => e.Descript).IsUnicode(false);

                entity.Property(e => e.RoutineName).IsUnicode(false);
            });
        }
    }
}
