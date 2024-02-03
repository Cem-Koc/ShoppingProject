using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingProject.Data.Context;
using ShoppingProject.Data.Repositories.Abstractions;
using ShoppingProject.Data.Repositories.Concretes;
using ShoppingProject.Data.UnitOfWorks;
using ShoppingProject.Service.Services.Abstractions;
using ShoppingProject.Service.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            services.AddScoped<IProductService,ProductService>();
            
            return services;
        }
    }
}
