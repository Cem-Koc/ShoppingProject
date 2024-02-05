using AutoMapper;
using ShoppingProject.Entity.DTOs.Categories;
using ShoppingProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Service.AutoMapper.Categories
{
	public class CategoryProfile:Profile
	{
        public CategoryProfile()
        {
            CreateMap<CategoryDto,Category>().ReverseMap();
        }
    }
}
