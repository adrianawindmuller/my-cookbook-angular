using Microsoft.Extensions.DependencyInjection;
using MyCookbook.Application.RecipesApplication;
using MyCookbook.Domain;
using MyCookbook.Domain.Recipes;
using MyCookbook.Infrastructure.Data.Repositories;

namespace MyCookbook.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionDefault(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRecipeApplication, RecipeApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();
        }
    }
}
