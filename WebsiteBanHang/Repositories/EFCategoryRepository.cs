using Microsoft.EntityFrameworkCore;
using WebsiteBanHang.DataAccess;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Repositories
{
	public class EFCategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _context;
		public EFCategoryRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public Task AddAsync(Category category)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await _context.Categories.ToListAsync();
		}

		public Task<Category> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Category category)
		{
			throw new NotImplementedException();
		}
	}
}
