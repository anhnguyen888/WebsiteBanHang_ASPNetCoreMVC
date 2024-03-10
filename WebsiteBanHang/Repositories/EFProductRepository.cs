using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.DataAccess;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Repositories
{
	public class EFProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public EFProductRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Product product)
		{
			_context.Products.Add(product);
			await _context.SaveChangesAsync();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			return await _context.Products.ToListAsync();
		}

		public Task<Product> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Product product)
		{
			throw new NotImplementedException();
		}
	}
}
