using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RiddleWebAPI.Models
{
    public partial class MyRiddleDatabaseContext : DbContext
    {
        public MyRiddleDatabaseContext()
        {
        }

        public MyRiddleDatabaseContext(DbContextOptions<MyRiddleDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Riddle> Riddles { get; set; }
        public virtual DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=ZSCHN01LP0042;Initial Catalog=MyRiddleDatabase;User ID=sa;Password=Password@1");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Riddle>(entity =>
            {
                entity.ToTable("Riddle");

                entity.Property(e => e.RiddleAnswer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RiddleQuestion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Riddles)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Riddle__Username__398D8EEE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__User__536C85E5E873245E");

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
