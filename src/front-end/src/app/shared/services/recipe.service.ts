import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppEnviroment } from './app-environment';
import { CardRecipe } from '../models/card-recipe.model';
import { Category } from '../models/category.model';
import { SaveRecipe } from '../models/save-recipe.model';
import { RecipeViewDetails } from '../models/recipe-view-details.model';
import { Observable, throwError } from 'rxjs';
import { CategoryWithRecipes } from '../models/category-with-recipes.model';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  private appEnviroment: AppEnviroment;

  constructor(private http: HttpClient) {
    this.appEnviroment = new AppEnviroment();
  }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(
      this.appEnviroment.categoryApi.getCategories()
    );
  }

  getCategoriesByIdWithRecipes(id: number): Observable<CategoryWithRecipes> {
    return this.http.get<CategoryWithRecipes>(
      this.appEnviroment.categoryApi.getCategoryByIdWithRecipes(id)
    );
  }

  getRecipes(): Observable<CardRecipe[]> {
    return this.http.get<CardRecipe[]>(
      this.appEnviroment.recipeApi.getRecipes()
    );
  }

  postRecipe(recipe: SaveRecipe): Observable<SaveRecipe> {
    return this.http.post<SaveRecipe>(
      this.appEnviroment.recipeApi.postRecipe(),
      recipe
    );
  }

  putRecipe(id: number, recipe: SaveRecipe): Observable<SaveRecipe> {
    return this.http.put<SaveRecipe>(
      this.appEnviroment.recipeApi.putRecipe(id),
      recipe
    );
  }

  getRecipeId(id: number): Observable<RecipeViewDetails> {
    return this.http.get<RecipeViewDetails>(
      this.appEnviroment.recipeApi.getRecipeDetailsById(id)
    );
  }

  getRecipeEditId(id: number): Observable<SaveRecipe> {
    return this.http.get<SaveRecipe>(
      this.appEnviroment.recipeApi.getRecipeEditById(id)
    );
  }

  deleteRecipeId(id: number): Observable<any> {
    return this.http.delete(this.appEnviroment.recipeApi.deleteRecipe(id));
  }

  toggleFavorite(id: number): Observable<any> {
    return this.http.put(this.appEnviroment.recipeApi.togglefavorite(id), null);
  }

  setRating(id: number, rate: number): Observable<any> {
    return this.http.put(
      this.appEnviroment.recipeApi.setRating(id, rate),
      null
    );
  }
}
