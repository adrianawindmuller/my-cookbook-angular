using Microsoft.Extensions.DependencyInjection;
using MyCookbook.Application.RecipesApplication;
using MyCookbook.Domain.Recipes;

namespace MyCookbook.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionDefault(this IServiceCollection services)
        {
            services.AddScoped<IRecipeApplication, RecipeApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();
        }
    }
}