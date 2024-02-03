﻿using Microsoft.AspNetCore.Mvc;
using ShoppingProject.Service.Services.Abstractions;

namespace ShoppingProject.WebUl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }
    }
}