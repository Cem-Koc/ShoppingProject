using AutoMapper;
using ShoppingProject.Data.UnitOfWorks;
using ShoppingProject.Entity.DTOs.Products;
using ShoppingProject.Entity.Entities;
using ShoppingProject.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Service.Services.Concrete
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task CreateProductAsync(ProductAddDto productAddDto)
		{
			var userId = Guid.Parse("ae6a5c1f-ad83-4cce-bf53-0739d89d3799");
			var product = new Product
			{
				Name = productAddDto.Name,
				Description = productAddDto.Description,
				CategoryId = productAddDto.CategoryId,
				UnitPrice = productAddDto.UnitPrice,
				UnitsInStock = productAddDto.UnitsInStock,
				UserId = userId
			};

			await _unitOfWork.GetRepository<Product>().AddAsync(product);
			await _unitOfWork.SaveAsync();
		}

		public async Task<List<ProductDto>> GetAllProductsWithCategoryNonDeletedAsync()
		{
			var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(x=>!x.IsDeleted,x=>x.Category);
			var map = _mapper.Map<List<ProductDto>>(products);
			return map;
		}
	}
}
