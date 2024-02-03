using ShoppingProject.Data.UnitOfWorks;
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

		public ProductService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}
        public async Task<List<Product>> GetAllProductsAsync()
		{
			return await _unitOfWork.GetRepository<Product>().GetAllAsync();
		}
	}
}
