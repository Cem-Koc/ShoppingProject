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
        public async Task<List<ProductDto>> GetAllProductsAsync()
		{
			var products = await _unitOfWork.GetRepository<Product>().GetAllAsync();
			var map = _mapper.Map<List<ProductDto>>(products);
			return map;
		}
	}
}
