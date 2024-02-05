using AutoMapper;
using ShoppingProject.Data.UnitOfWorks;
using ShoppingProject.Entity.DTOs.Categories;
using ShoppingProject.Entity.Entities;
using ShoppingProject.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Service.Services.Concrete
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public CategoryService(IUnitOfWork unitOfWork,IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
		{
			var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x=>!x.IsDeleted);
			var map = _mapper.Map<List<CategoryDto>>(categories);

			return map;
		}
	}
}
