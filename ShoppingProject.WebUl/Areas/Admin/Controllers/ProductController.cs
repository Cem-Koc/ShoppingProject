using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Entity.DTOs.Products;
using ShoppingProject.Service.Services.Abstractions;

namespace ShoppingProject.WebUl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public ProductController(IProductService productService,ICategoryService categoryService)
        {
			_productService = productService;
			_categoryService = categoryService;
		}
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsWithCategoryNonDeletedAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            return View(new ProductAddDto { Categories = categories});
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            await _productService.CreateProductAsync(productAddDto);
            return RedirectToAction("Index","Product",new {Area = "Admin"});
		}
    }
}
