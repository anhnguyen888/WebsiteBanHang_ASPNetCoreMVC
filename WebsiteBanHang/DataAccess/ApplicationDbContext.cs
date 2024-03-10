using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace WebsiteBanHang.DataAccess
{
	public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
	}
}
