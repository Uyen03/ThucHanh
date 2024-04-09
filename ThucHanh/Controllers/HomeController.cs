using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThucHanh.Models;
using ThucHanh.Repositories;

namespace ThucHanh.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;

        /* public HomeController(ILogger<HomeController> logger)
         {
             _logger = logger;
         }*/
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);


        }

        public IActionResult Search(string keyword)
        {
            // ?i?u h??ng ng??i dùng ??n trang hi?n th? k?t qu? tìm ki?m v?i t? khóa ?ã nh?p
            return RedirectToAction("SearchResult", new { keyword = keyword });
        }

        public async Task<IActionResult> SearchResult(string keyword)
        {
            var products = await _productRepository.SearchAsync(keyword);
            return View(products);

            /*var products = await _productRepository.SearchAsync(keyword);
            return View("Index", products); // Sử dụng view "Index" để hiển thị danh sách sản phẩm*/
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
