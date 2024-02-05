using ShoppingProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Entity.Entities
{
	public class Product:EntityBase
	{
		public string Name { get; set; }
		public string Description { get; set; }
        public int UnitsInStock { get; set; }
		public decimal UnitPrice { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

    }
}
