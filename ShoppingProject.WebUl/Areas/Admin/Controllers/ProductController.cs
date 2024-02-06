using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ShoppingProject.Entity.DTOs.Products;
using ShoppingProject.Entity.Entities;
using ShoppingProject.Service.Extensions;
using ShoppingProject.Service.Services.Abstractions;
using ShoppingProject.WebUl.ResultMessages;

namespace ShoppingProject.WebUl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;
		private readonly IValidator<Product> _validator;
		private readonly IToastNotification _toast;

		public ProductController(IProductService productService,ICategoryService categoryService,IMapper mapper,IValidator<Product> validator,IToastNotification toast)
        {
			_productService = productService;
			_categoryService = categoryService;
			_mapper = mapper;
			_validator = validator;
			_toast = toast;
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
            var map = _mapper.Map<Product>(productAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
				await _productService.CreateProductAsync(productAddDto);
                _toast.AddSuccessToastMessage(Messages.Product.Add(productAddDto.Name),new ToastrOptions { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "Product", new { Area = "Admin" });
			}
            else
            {
				result.AddToModelState(this.ModelState);
				var categories = await _categoryService.GetAllCategoriesNonDeleted();
				return View(new ProductAddDto { Categories = categories });
			}           			
		}

        [HttpGet]
        public async Task<IActionResult> Update(Guid productId)
        {
            var product = await _productService.GetProductWithCategoryNonDeletedAsync(productId);
            var categories = await _categoryService.GetAllCategoriesNonDeleted();

            var productUpdateDto = _mapper.Map<ProductUpdateDto>(product);
            productUpdateDto.Categories = categories;

            return View(productUpdateDto);
        }

		[HttpPost]
		public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
		{
			var map = _mapper.Map<Product>(productUpdateDto);
			var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
				var name = await _productService.UpdateProductAsync(productUpdateDto);
                _toast.AddSuccessToastMessage(Messages.Product.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "Product", new { Area = "Admin" });
			}
            else
            {
                result.AddToModelState(this.ModelState);
            }            

            var categories = await _categoryService.GetAllCategoriesNonDeleted();
            productUpdateDto.Categories = categories;
            return View(productUpdateDto);
        }

        public async Task<IActionResult> Delete(Guid productId)
        {
            var name = await _productService.SafeDeleteProductAsync(productId);
			_toast.AddSuccessToastMessage(Messages.Product.Delete(name), new ToastrOptions { Title = "İşlem Başarılı" });
			return RedirectToAction("Index", "Product", new { Area = "Admin" });
        }
	}
}
