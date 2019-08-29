using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WinterReverse.Models;

namespace WinterReverse.Models
{
    public partial class WinteringPrototypeContext : DbContext
    {
        public WinteringPrototypeContext()
        {
        }

        public WinteringPrototypeContext(DbContextOptions<WinteringPrototypeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Resorts> Resorts { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketTypes> TicketTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-F0A7DDSD\\SQLEXPRESS;Database=WinteringPrototype;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Resorts>(entity =>
            {
                entity.HasKey(e => e.ResortId);

                entity.Property(e => e.ResortId).HasColumnName("ResortID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ResortName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId).HasColumnName("TicketID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ResortId).HasColumnName("ResortID");

                entity.Property(e => e.TicketTypeId).HasColumnName("TicketTypeID");

                entity.HasOne(d => d.TicketType)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.TicketTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ticket__TicketTy__403A8C7D");
            });

            modelBuilder.Entity<TicketTypes>(entity =>
            {
                entity.HasKey(e => e.TicketTypeId);

                entity.Property(e => e.TicketTypeId).HasColumnName("TicketTypeID");
            });
        }

        public DbSet<WinterReverse.Models.Blog> Blog { get; set; }
    }
}
