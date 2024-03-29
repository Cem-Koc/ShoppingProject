﻿using ShoppingProject.Entity.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Entity.DTOs.Products
{
	public class ProductDto
	{
        public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int UnitsInStock { get; set; }
		public decimal UnitPrice { get; set; }
		public CategoryDto Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
	}
}
