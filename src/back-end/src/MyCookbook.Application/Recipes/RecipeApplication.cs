﻿using MyCookbook.Domain.Common;
using MyCookbook.Domain.Recipes;
using MyCookbook.Domain.Recipes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookbook.Application.RecipesApplication
{
    public class RecipeApplication : IRecipeApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeApplication(
            IUserRepository userRepository,
            ICategoryRepository categoryRepository,
            IRecipeRepository recipeRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _recipeRepository = recipeRepository;
        }

        public async Task<Response> RegisterRecipe(RegisterRecipeDto dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user is null)
            {
                return Response.NotFound($"User {dto.UserId} não encontrada.");
            }

            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
            if (category is null)
            {
                return Response.NotFound($"Categoria {dto.CategoryId} não encontrada.");
            }

            var imagens = dto.Images.Select(i => new Image(i)).ToList();

            var recipe = new Recipe(
                dto.Name,
                user,
                category,
                dto.NumberPortion,
                dto.PreparationTimeInMinutes,
                dto.Ingredients,
                dto.PreparationMode,
                imagens,
                dto.Published);


            await _recipeRepository.AddAsync(recipe);
            await _recipeRepository.UnitOfWork.CommitAsync();

            var vmRecipe = new List<RegisterRecipeViewModel>
            {
                new RegisterRecipeViewModel { Id = recipe.Id, Name = recipe.Name, UserId = recipe.User.Id }
            };

            return Response.Created(vmRecipe);
        }


        public async Task<Response> PutRecipe(int id, RegisterRecipeDto dto)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe is null)
            {
                return Response.NotFound($"Receita {id} não encontrada");
            }

            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user is null)
            {
                return Response.NotFound($"User {dto.UserId} não encontrada.");
            };

            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);
            if (category is null)
            {
                return Response.NotFound($"Categoria {dto.CategoryId}");
            };

            var images = dto.Images.Select(i => new Image(i)).ToList();

            recipe.Edit(
                dto.Name,
                user,
                category,
                dto.NumberPortion,
                dto.PreparationTimeInMinutes,
                dto.Ingredients,
                dto.PreparationMode,
                dto.Published,
                images
                );

            _recipeRepository.Update(recipe);
            await _recipeRepository.UnitOfWork.CommitAsync();

            return Response.NoContent();
        }

        public async Task<Response> DeleteRecipe(int id)
        {
            var recipe = _recipeRepository.GetByIdAsync(id);

            if (recipe is null)
            {
                return Response.NotFound($"Receita {id} não encontrada");
            }

            _recipeRepository.Delete(recipe.Result);
            await _recipeRepository.UnitOfWork.CommitAsync();

            return Response.NoContent();
        }

        public async Task<Response> GetRecipe()
        {
            var recipes = await _recipeRepository.ListAllAsync();
            var vmRecipes = new List<CardRecipeViewModel>();


            foreach (var recipe in recipes)
            {
                var vmRecipe = new CardRecipeViewModel
                {
                    Id = recipe.Id,
                    UserId = recipe.User.Id,
                    UserName = recipe.User.Name,
                    Name = recipe.Name,
                    CategoryName = recipe.Category.Name,
                    Favorite = recipe.Favorite,
                };

                foreach (var image in recipe.Images)
                {
                    vmRecipe.Images.Add(image.RawContent);
                }

                vmRecipes.Add(vmRecipe);
            }
            return Response.Ok(vmRecipes);
        }

        public async Task<Response> GetRecipeDetails(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe is null)
            {
                return Response.NotFound($"Recipe {recipe.Id} não encontrada.");
            }

            var imageVm = new List<string>();
            foreach (var image in recipe.Images)
            {
                imageVm.Add(image.RawContent);
            }

            var vmRecipe = new GetRecipeDetailsViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                UserId = recipe.User.Id,
                UserName = recipe.User.Name,
                CategoryName = recipe.Category.Name,
                NumberPortion = recipe.NumberPortion,
                PreparationTimeInMinutes = recipe.PreparationTimeInMinutes,
                Ingredients = recipe.Ingredients,
                PreparationMode = recipe.PreparationMode,
                Images = imageVm,
                Favorite = recipe.Favorite,
                Rating = recipe.Rating,
            };

            return Response.Ok(vmRecipe);
        }

        public async Task<Response> GetRecipeEdit(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe is null)
            {
                return Response.NotFound($"Receita {id} não encontrada.");
            }

            var imagesVm = new List<string>();
            foreach (var image in recipe.Images)
            {
                imagesVm.Add(image.RawContent);
            }

            var vm = new RegisterRecipeViewModel
            {
                Id = recipe.Id,
                Name = recipe.Name,
                CategoryId = recipe.Category.Id,
                UserId = recipe.User.Id,
                NumberPortion = recipe.NumberPortion,
                PreparationTimeInMinutes = recipe.PreparationTimeInMinutes,
                Ingredients = recipe.Ingredients,
                PreparationMode = recipe.PreparationMode,
                Images = imagesVm,
                Published = recipe.Published
            };

            return Response.Ok(vm);

        }

        public async Task<Response> ToggleFavoriteAsync(int id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe is null)
            {
                return Response.NotFound($"Receita {id} não encontrada.");
            }

            recipe.ToogleFavorite();
            _recipeRepository.Update(recipe);
            await _recipeRepository.UnitOfWork.CommitAsync();

            return Response.NoContent();
        }

        public async Task<Response> SetRatingAsync(int id, int rate)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe is null)
            {
                return Response.NotFound($"Receita {id} não encontrada.");
            }

            recipe.SetRating(rate);
            _recipeRepository.Update(recipe);
            await _recipeRepository.UnitOfWork.CommitAsync();

            return Response.NoContent();
        }

        public async Task<Response> FilterRecipe(string name)
        {

            throw new NotImplementedException();
        }
    }
}