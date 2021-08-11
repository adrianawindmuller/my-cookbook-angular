import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { AppEnviroment } from './app-environment';
import { CardRecipe } from './models/card-recipe.model';
import { Category } from './models/category';
import { SaveRecipe } from './models/save-recipe.model';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Router } from '@angular/router';
import { RecipeViewDetails } from './models/recipe-view-details.model';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  private appEnviroment: AppEnviroment;

  constructor(private http: HttpClient, private route: Router) {
    this.appEnviroment = new AppEnviroment();
  }

  getRecipes() {
    return this.http.get<CardRecipe[]>(this.appEnviroment.recipeApi.get());
  }

  getCategories() {
    return this.http.get<Category[]>(this.appEnviroment.categoryApi.get());
  }

  postRecipe(recipe: SaveRecipe) {
    return this.http.post<SaveRecipe>(
      this.appEnviroment.recipeApi.post(),
      recipe
    );
  }

  putRecipe(id: number, recipe: SaveRecipe) {
    return this.http.put<SaveRecipe>(
      this.appEnviroment.recipeApi.put(id),
      recipe
    );
  }

  getRecipeId(id: number) {
    return this.http.get<RecipeViewDetails>(
      this.appEnviroment.recipeApi.getDetailsById(id)
    );
  }

  getRecipeEditId(id: number) {
    return this.http.get<SaveRecipe>(
      this.appEnviroment.recipeApi.getEditById(id)
    );
  }

  deleteRecipeId(id: number) {
    return this.http.delete(this.appEnviroment.recipeApi.delete(id));
  }

  toggleFavorite(id: number) {
    return this.http.put(this.appEnviroment.recipeApi.togglefavorite(id), null);
  }

  setRating(id: number, rate: number) {
    return this.http.put(
      this.appEnviroment.recipeApi.setRating(id, rate),
      null
    );
  }
}
