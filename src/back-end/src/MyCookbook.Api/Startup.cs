using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCookbook.Application.RecipesApplication;
using MyCookbook.Domain;
using MyCookbook.Domain.Recipes;
using MyCookbook.Domain.Recipes.Dtos;
using MyCookbook.Infrastructure.Data.DbContexts;
using MyCookbook.Infrastructure.Data.Repositories;

namespace MyCookbook.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            }).AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<RegisterRecipeValidator>();
                fv.ImplicitlyValidateChildProperties = true;

            });

            services.AddCors(c =>
            {
                c.AddPolicy("CorsDefault", p =>
                    p.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod());
            });

            services.AddSwaggerGen();

            services.AddDbContext<MyCookBookDbContext>(c =>
            {
                c.UseSqlServer(_configuration.GetConnectionString("MyCookBookConnection"));
            });


            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRecipeApplication, RecipeApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsDefault");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });



        }
    }
}
