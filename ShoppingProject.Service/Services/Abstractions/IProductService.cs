﻿using ShoppingProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Service.Services.Abstractions
{
	public interface IProductService
	{
		Task<List<Product>> GetAllProductsAsync();
	}
}
