using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShoppingProject.Data.UnitOfWorks;
using ShoppingProject.Entity.DTOs.Products;
using ShoppingProject.Entity.Entities;
using ShoppingProject.Service.Extensions;
using ShoppingProject.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Service.Services.Concrete
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;

		public ProductService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
		}

		public async Task CreateProductAsync(ProductAddDto productAddDto)
		{
			var userId = _user.GetLoggedInUserId();
			var userEmail = _user.GetLoggedInEmail();

			var product = new Product(productAddDto.Name,productAddDto.Description,productAddDto.UnitsInStock,productAddDto.UnitPrice,productAddDto.CategoryId,userId,userEmail);

			await _unitOfWork.GetRepository<Product>().AddAsync(product);
			await _unitOfWork.SaveAsync();
		}

		public async Task<List<ProductDto>> GetAllProductsWithCategoryNonDeletedAsync()
		{
			var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(x=>!x.IsDeleted,x=>x.Category);
			var map = _mapper.Map<List<ProductDto>>(products);
			return map;
		}

		public async Task<ProductDto> GetProductWithCategoryNonDeletedAsync(Guid productId)
		{
			var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => !x.IsDeleted && x.Id == productId, x => x.Category);
			var map = _mapper.Map<ProductDto>(product);
			return map;
		}

		public async Task<string> UpdateProductAsync(ProductUpdateDto productUpdateDto)
		{
			var userEmail = _user.GetLoggedInEmail();
			var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => !x.IsDeleted && x.Id == productUpdateDto.Id, x => x.Category);

			product.Name = productUpdateDto.Name;
			product.Description = productUpdateDto.Description;
			product.UnitPrice = productUpdateDto.UnitPrice;
			product.UnitsInStock = productUpdateDto.UnitsInStock;
			product.CategoryId = productUpdateDto.CategoryId;
			product.ModifiedDate = DateTime.Now;
			product.ModifiedBy = userEmail;

			await _unitOfWork.GetRepository<Product>().UpdateAsync(product);
			await _unitOfWork.SaveAsync();

			return product.Name;
		}

		public async Task<string> SafeDeleteProductAsync(Guid productId)
		{
			var userEmail = _user.GetLoggedInEmail();
			var product = await _unitOfWork.GetRepository<Product>().GetByGuidAsync(productId);

			product.IsDeleted = true;
			product.DeletedDate = DateTime.Now;
			product.DeletedBy = userEmail;

			await _unitOfWork.GetRepository<Product>().UpdateAsync(product);
			await _unitOfWork.SaveAsync();

			return product.Name;
		}
	}
}
