using Microsoft.EntityFrameworkCore;

namespace Shop.Server.Models.ApplicationDbContext
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
	}
}
