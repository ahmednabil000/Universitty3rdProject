using Microsoft.EntityFrameworkCore;

namespace Shop.Server.Models;

public partial class DbAa7408UniversityprojectContext : DbContext
{
	public DbAa7408UniversityprojectContext()
	{
	}

	public DbAa7408UniversityprojectContext(DbContextOptions<DbAa7408UniversityprojectContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Admin> Admins { get; set; }

	public virtual DbSet<Bill> Bills { get; set; }

	public virtual DbSet<Customer> Customers { get; set; }

	public virtual DbSet<Feedback> Feedbacks { get; set; }

	public virtual DbSet<Order> Orders { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Data Source=SQL6031.site4now.net;Initial Catalog=db_aa7408_universityproject;User Id=db_aa7408_universityproject_admin;Password=ahmed3400");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Admin>(entity =>
		{
			entity.ToTable("Admin");

			entity.Property(e => e.AdminId)
				.ValueGeneratedNever()
				.HasColumnName("admin_id");
			entity.Property(e => e.Email)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasColumnName("email");
			entity.Property(e => e.Password)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasColumnName("password");
		});

		modelBuilder.Entity<Bill>(entity =>
		{
			entity.HasKey(e => e.BId);

			entity.ToTable("bill");

			entity.Property(e => e.BId)
				.ValueGeneratedNever()
				.HasColumnName("B_id");
			entity.Property(e => e.CId).HasColumnName("c_id");
			entity.Property(e => e.CName)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("c_name");
			entity.Property(e => e.PId).HasColumnName("p_id");
			entity.Property(e => e.PName)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("p_name");

			entity.HasOne(d => d.Customer).WithMany(p => p.Bills)
				.HasForeignKey(d => d.CId)
				.OnDelete(DeleteBehavior.Cascade)
				.HasConstraintName("FK_bill_customer");


		});

		modelBuilder.Entity<Customer>(entity =>
		{
			entity.HasKey(e => e.CId);

			entity.ToTable("customer");

			entity.Property(e => e.CId)
				.ValueGeneratedNever()
				.HasColumnName("c_id");
			entity.Property(e => e.CName)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasColumnName("c_name");
			entity.Property(e => e.Email)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasColumnName("email");
			entity.Property(e => e.Password)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasColumnName("password");
			entity.Property(e => e.RePassword)
				.HasMaxLength(20)
				.IsUnicode(false)
				.HasColumnName("re_password");
		});

		modelBuilder.Entity<Feedback>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("feedback");

			entity.Property(e => e.CName)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("c_name");
			entity.Property(e => e.CNumber).HasColumnName("c_number");
			entity.Property(e => e.City)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("city");
			entity.Property(e => e.Email)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("email");
		});

		modelBuilder.Entity<Order>(entity =>
		{
			entity.HasKey(e => e.OId);

			entity.ToTable("order");

			entity.Property(e => e.OId)
				.ValueGeneratedNever()
				.HasColumnName("o_id");
			entity.Property(e => e.CId).HasColumnName("c_id");
			entity.Property(e => e.CName)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("c_name");
			entity.Property(e => e.PId).HasColumnName("p_id");
			entity.Property(e => e.PName)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("p_name");
			entity.Property(e => e.Price).HasColumnName("price");

			entity.HasOne(o => o.Customer).WithMany(c => c.Orders)
			.HasForeignKey(o => o.CId)
			.OnDelete(DeleteBehavior.Cascade);


		});

		modelBuilder.Entity<Product>(entity =>
		{
			entity.HasKey(e => e.PId);

			entity.ToTable("product");

			entity.Property(e => e.PId)
				.ValueGeneratedNever()
				.HasColumnName("p_id");
			entity.Property(e => e.PDesc)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("p_desc");
			entity.Property(e => e.PName)
				.HasMaxLength(50)
				.IsUnicode(false)
				.HasColumnName("p_name");
			entity.Property(e => e.PPrice).HasColumnName("p_price");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
