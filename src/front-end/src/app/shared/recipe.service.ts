import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from './category.model';
import { Recipe } from './recipe.model';
import { AppEnviroment } from './app-environment';
import { CardRecipe } from './card-recipe.model';
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

  getCategoryId(id: number) {
    return this.http.get<Category>(
      this.appEnviroment.categoryApi.categoryId(id)
    );
  }

  createNewRecipe(recipe: Recipe) {
    return this.http.post<Recipe>(this.API_Recipe, recipe);
  }

  getRecipes() {
    return this.http.get<CardRecipe[]>(this.appEnviroment.recipeApi.recipe());
  }

  getRecipeId(id: number) {
    return this.http.get<Recipe>(`${this.API_Recipe}/${id}`);
  }

  addFavoriteRecipe(recipe: Recipe) {
    return this.http.put(`${this.API_Recipe}/${recipe.id}`, recipe);
  }

  addRating(recipe: Recipe) {
    return this.http.put(`${this.API_Recipe}/${recipe.id}`, recipe);
  }

  deleteRecipe(id: number) {
    return this.http.delete(`${this.API_Recipe}/${id}`);
  }

  updateRecipe(recipe: Recipe) {
    return this.http.put(`${this.API_Recipe}/${recipe.id}`, recipe);
  }
}
