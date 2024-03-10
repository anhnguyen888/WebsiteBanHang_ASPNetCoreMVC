using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebsiteBanHang.Models;
using WebsiteBanHang.Repositories;

namespace WebsiteBanHang.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;

		public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
		{
			_productRepository = productRepository;
			_categoryRepository = categoryRepository;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _productRepository.GetAllAsync();
			return View(products);
		}

		// Hiển thị form thêm sản phẩm mới
		public async Task<IActionResult> Add()
		{
			var categories = await _categoryRepository.GetAllAsync();
			ViewBag.Categories = new SelectList(categories, "Id", "Name");
			return View();
		}
		// Xử lý thêm sản phẩm mới
		[HttpPost]
		public async Task<IActionResult> Add(Product product)
		{
			if (ModelState.IsValid)
			{
				await _productRepository.AddAsync(product);
				return RedirectToAction(nameof(Index));
			}
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }
            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var categories = await _categoryRepository.GetAllAsync();
			ViewBag.Categories = new SelectList(categories, "Id", "Name");
			return View(product);
		}

		// Hiển thị form cập nhật sản phẩm
		public async Task<IActionResult> Update(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null){
				return NotFound();
			}
			var categories = await _categoryRepository.GetAllAsync();
			ViewBag.Categories = new SelectList(categories, "Id", "Name",
			product.CategoryId);
			return View(product);
		}
		// Xử lý cập nhật sản phẩm
		[HttpPost]
		public async Task<IActionResult> Update(int id, Product product)
		{
			if (id != product.Id)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				await _productRepository.UpdateAsync(product);
				return RedirectToAction(nameof(Index));
			}
			return View(product);
		}

	}
}
