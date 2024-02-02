using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Data.Mappings
{
	public class ProductMap : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasData(new Product
			{
				Id=Guid.NewGuid(),
				Name="Polo Yaka Kazak",
				Description= "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
				Quantity=200,
				Price=1500,
				CategoryId = Guid.Parse("9a99ad62-b618-4dca-a254-5843255ab008"),
				CreatedBy = "Admin Test",
				CreatedDate= DateTime.Now,
				IsDeleted=false
			},
			new Product
			{
				Id = Guid.NewGuid(),
				Name = "Polo Yaka T-Shirt",
				Description = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
				Quantity = 100,
				Price = 500,
				CategoryId=Guid.Parse("9ec7d5a6-ee4a-4f21-885a-21a89e95559d"),
				CreatedBy = "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false
			}	
			);
		}
	}
}
