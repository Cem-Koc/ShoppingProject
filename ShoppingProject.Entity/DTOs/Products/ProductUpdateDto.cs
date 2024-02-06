using ShoppingProject.Entity.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Entity.DTOs.Products
{
	public class ProductUpdateDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int UnitsInStock { get; set; }
		public decimal UnitPrice { get; set; }
		public Guid CategoryId { get; set; }

		public IList<CategoryDto> Categories { get; set; }
	}
}
