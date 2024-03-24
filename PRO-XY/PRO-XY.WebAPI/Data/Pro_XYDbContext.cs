using Microsoft.EntityFrameworkCore;
using PRO_XY.WebAPI.Data.Interfaces;
using PRO_XY.WebAPI.Entities;

namespace PRO_XY.WebAPI.Data
{
  public partial class Pro_XYDbContext : DbContext, IProXYDbContext
  {
    public Pro_XYDbContext(DbContextOptions<Pro_XYDbContext> options)
        : base(options) { }

    public virtual DbSet<Dashboard> Dashboards { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<SharedDashboard> SharedDashboards { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<SampleSuperstore> SampleSuperstores { get; set; }

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
        entity.HasIndex(e => e.RoleName, "UQ__Roles__035DB749860BB51C")
            .IsUnique();

        entity.Property(e => e.Description).HasColumnType("text");

        entity.Property(e => e.RoleName)
            .IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("Role_Name");
      });

      modelBuilder.Entity<SampleSuperstore>(entity =>
      {
        entity.HasKey(e => e.RowId);

        entity.ToTable("SampleSuperstore");

        entity.Property(e => e.RowId)
            .ValueGeneratedNever()
            .HasColumnName("Row_ID");

        entity.Property(e => e.Category).HasMaxLength(50);

        entity.Property(e => e.City).HasMaxLength(50);

        entity.Property(e => e.CountryRegion)
            .HasMaxLength(50)
            .HasColumnName("Country_Region");

        entity.Property(e => e.CustomerId)
            .HasMaxLength(50)
            .HasColumnName("Customer_ID");

        entity.Property(e => e.CustomerName)
            .HasMaxLength(50)
            .HasColumnName("Customer_Name");

        entity.Property(e => e.OrderDate)
            .HasColumnType("date")
            .HasColumnName("Order_Date");

        entity.Property(e => e.OrderId)
            .HasMaxLength(50)
            .HasColumnName("Order_ID");

        entity.Property(e => e.PostalCode).HasColumnName("Postal_Code");

        entity.Property(e => e.ProductId)
            .HasMaxLength(50)
            .HasColumnName("Product_ID");

        entity.Property(e => e.ProductName)
            .HasMaxLength(150)
            .HasColumnName("Product_Name");

        entity.Property(e => e.Region).HasMaxLength(50);

        entity.Property(e => e.Segment).HasMaxLength(50);

        entity.Property(e => e.ShipDate)
            .HasColumnType("date")
            .HasColumnName("Ship_Date");

        entity.Property(e => e.ShipMode)
            .HasMaxLength(50)
            .HasColumnName("Ship_Mode");

        entity.Property(e => e.State).HasMaxLength(50);

        entity.Property(e => e.SubCategory)
            .HasMaxLength(50)
            .HasColumnName("Sub_Category");
      });

      modelBuilder.Entity<SharedDashboard>(entity =>
      {
        entity.Property(e => e.DashboardId).HasColumnName("Dashboard_Id");

        entity.Property(e => e.UserId).HasColumnName("User_Id");

        entity.HasOne(d => d.Dashboard)
            .WithMany(p => p.SharedDashboards)
            .HasForeignKey(d => d.DashboardId)
            .HasConstraintName("FK__SharedDas__Dashb__3C69FB99");

        entity.HasOne(d => d.User)
            .WithMany(p => p.SharedDashboards)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK__SharedDas__User___3B75D760");
      });

      modelBuilder.Entity<User>(entity =>
      {
        entity.HasIndex(e => e.UserName, "UQ__Users__681E8A607174021F")
            .IsUnique();

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
