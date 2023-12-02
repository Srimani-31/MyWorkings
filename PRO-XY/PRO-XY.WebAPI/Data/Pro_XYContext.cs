using Microsoft.EntityFrameworkCore;
using PRO_XY.WebAPI.Data.Interfaces;
using PRO_XY.WebAPI.Entities;

namespace PRO_XY.WebAPI.Data
{
  public partial class PRO_XYContext : DbContext, IProXYDbContext
  {
    public PRO_XYContext(DbContextOptions<PRO_XYContext> options)
        : base(options) { }

    public virtual DbSet<Dashboard> Dashboards { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<SharedDashboard> SharedDashboards { get; set; }
    public virtual DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

      modelBuilder.Entity<Dashboard>(entity =>
      {
        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.JsonValue)
                  .IsRequired()
                  .IsUnicode(false)
                  .HasColumnName("Json_Value");
      });

      modelBuilder.Entity<Role>(entity =>
      {
        entity.HasIndex(e => e.RoleName, "UQ__Roles__035DB7497ED1EC8F")
                  .IsUnique();

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.Description).HasColumnType("text");

        entity.Property(e => e.RoleName)
                  .IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false)
                  .HasColumnName("Role_Name");
      });

      modelBuilder.Entity<SharedDashboard>(entity =>
      {
        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.DashboardId).HasColumnName("Dashboard_Id");

        entity.Property(e => e.UserId).HasColumnName("User_Id");

        entity.HasOne(d => d.Dashboard)
                  .WithMany(p => p.SharedDashboards)
                  .HasForeignKey(d => d.DashboardId)
                  .HasConstraintName("FK__SharedDas__Dashb__31EC6D26");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.SharedDashboards)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("FK__SharedDas__User___30F848ED");
      });

      modelBuilder.Entity<User>(entity =>
      {
        entity.HasIndex(e => e.UserName, "UQ__Users__681E8A60E6635C31")
                  .IsUnique();

        entity.Property(e => e.Id).ValueGeneratedNever();

        entity.Property(e => e.Address)
                  .HasMaxLength(255)
                  .IsUnicode(false);

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

        entity.Property(e => e.Password)
                  .IsRequired()
                  .HasMaxLength(255);

        entity.Property(e => e.PhoneNo)
                  .HasMaxLength(20)
                  .IsUnicode(false)
                  .HasColumnName("Phone_No");

        entity.Property(e => e.RoleId).HasColumnName("Role_Id");

        entity.Property(e => e.UserName)
                  .IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false)
                  .HasColumnName("User_Name");

        entity.HasOne(d => d.Role)
                  .WithMany(p => p.Users)
                  .HasForeignKey(d => d.RoleId)
                  .HasConstraintName("FK__Users__Role_Id__286302EC");
      });

      OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

  }
}
