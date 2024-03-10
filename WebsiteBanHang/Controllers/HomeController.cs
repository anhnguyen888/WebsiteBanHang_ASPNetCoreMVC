using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebsiteBanHang.Models;
using WebsiteBanHang.Repositories;
namespace WebsiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            //lay san pham
            //var products = await _productRepository.GetAllAsync();
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}