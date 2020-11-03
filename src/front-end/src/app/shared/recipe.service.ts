import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from './models/category.model';
import { Recipe } from './recipe.model';
import { AppEnviroment } from './app-environment';
import { CardRecipe } from './models/card-recipe.model';
import { RecipeViewDetails } from './models/recipe-view-details.model';
import { RecipeRegister } from './models/recipe-register.model';
@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  private API_Recipe = 'http://localhost:3000/recipe';
  private appEnviroment: AppEnviroment;

  constructor(private http: HttpClient) {
    this.appEnviroment = new AppEnviroment();
  }

  getCategory() {
    return this.http.get<Category[]>(this.appEnviroment.categoryApi.category());
  }

  createNewRecipe(recipe: RecipeRegister) {
    return this.http.post<RecipeRegister>(
      this.appEnviroment.recipeApi.registerRecipe(),
      recipe
    );
  }

  updateRecipe(recipe: RecipeRegister) {
    return this.http.put(
      this.appEnviroment.recipeApi.recipeIdEdit(recipe.id),
      recipe
    );
  }

  getRecipes() {
    return this.http.get<CardRecipe[]>(this.appEnviroment.recipeApi.recipe());
  }

  getRecipeId(id: number) {
    return this.http.get<RecipeViewDetails>(
      this.appEnviroment.recipeApi.recipeId(id)
    );
  }

  getRecipeIdEdit(id: number) {
    return this.http.get<RecipeRegister>(
      this.appEnviroment.recipeApi.recipeIdEdit(id)
    );
  }

  ToggleFavoriteRecipe(id: number) {
    return this.http.put(this.appEnviroment.recipeApi.toggleFavorite(id), 0);
  }

  SetRating(id: number, rating: number) {
    return this.http.put(this.appEnviroment.recipeApi.setRating(id, rating), 0);
  }

  deleteRecipe(id: number) {
    return this.http.delete(`${this.API_Recipe}/${id}`);
  }
}
