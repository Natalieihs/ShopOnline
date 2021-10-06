using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using ApplicationCore;

namespace Web.Configuration
{
    public static class ConfigureWebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(BasketViewModelService).Assembly);
            services.AddScoped<IBasketViewModelService, BasketViewModelService>();
            services.AddScoped<CatalogViewModelService>();
            services.AddScoped<ICatalogItemViewModelService, CatalogItemViewModelService>();
            services.Configure<CatalogSettings>(configuration);
            services.AddScoped<ICatalogViewModelService, CachedCatalogViewModelService>();

            return services;
        }
    }
}
