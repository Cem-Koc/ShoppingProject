using AutoMapper;
using ShoppingProject.Entity.DTOs.Products;
using ShoppingProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Service.AutoMapper.Products
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductDto,Product>().ReverseMap();
		}
	}
}
