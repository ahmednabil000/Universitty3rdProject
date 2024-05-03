using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Shop.Server.Models;

public partial class DbAa7408UniversityprojectContext : IdentityDbContext<IdentityUser>
{
	public DbAa7408UniversityprojectContext()
	{
	}

	public DbAa7408UniversityprojectContext(DbContextOptions<DbAa7408UniversityprojectContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Order> Orders { get; set; }
	public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
	public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
	public virtual DbSet<OrderItem> OrderItems { get; set; }
	public virtual DbSet<Product> Products { get; set; }
	public virtual DbSet<Feedback> Feedbacks { get; set; }
	public virtual DbSet<UsersPurchasedProducts> UserPurchasedProducts { get; set; }


	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Data Source=SQL6031.site4now.net;Initial Catalog=db_aa7408_universityproject;User Id=db_aa7408_universityproject_admin;Password=ahmed3400");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		OnModelCreatingPartial(modelBuilder);

		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
