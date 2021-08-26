import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AppEnviroment } from './app-environment';
import { CardRecipe } from './models/card-recipe.model';
import { Category } from './models/category';
import { SaveRecipe } from './models/save-recipe.model';
import { RecipeViewDetails } from './models/recipe-view-details.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  private appEnviroment: AppEnviroment;

  constructor(private http: HttpClient) {
    this.appEnviroment = new AppEnviroment();
  }

  getRecipes(): Observable<CardRecipe[]> {
    return this.http.get<CardRecipe[]>(this.appEnviroment.recipeApi.get());
  }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.appEnviroment.categoryApi.get());
  }

  postRecipe(recipe: SaveRecipe): Observable<SaveRecipe> {
    return this.http.post<SaveRecipe>(
      this.appEnviroment.recipeApi.post(),
      recipe
    );
  }

  putRecipe(id: number, recipe: SaveRecipe): Observable<SaveRecipe> {
    return this.http.put<SaveRecipe>(
      this.appEnviroment.recipeApi.put(id),
      recipe
    );
  }

  getRecipeId(id: number): Observable<RecipeViewDetails> {
    return this.http.get<RecipeViewDetails>(
      this.appEnviroment.recipeApi.getDetailsById(id)
    );
  }

  getRecipeEditId(id: number): Observable<SaveRecipe> {
    return this.http.get<SaveRecipe>(
      this.appEnviroment.recipeApi.getEditById(id)
    );
  }

  deleteRecipeId(id: number): Observable<any> {
    return this.http.delete(this.appEnviroment.recipeApi.delete(id));
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
