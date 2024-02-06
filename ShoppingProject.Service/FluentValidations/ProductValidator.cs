using FluentValidation;
using ShoppingProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Service.FluentValidations
{
	public class ProductValidator:AbstractValidator<Product>
	{
        public ProductValidator()
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(150)
                .WithName("Ürün Adı");

			RuleFor(x => x.Description)
				.NotEmpty()
				.NotNull()
				.MinimumLength(2)
				.MaximumLength(150)
				.WithName("Ürün Açıklaması");
		}
    }
}
