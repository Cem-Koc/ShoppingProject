﻿using ShoppingProject.Entity.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Service.Services.Abstractions
{
	public interface ICategoryService
	{
		public Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
	}
}
