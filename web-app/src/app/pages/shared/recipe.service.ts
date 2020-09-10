import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../shared/step/category.model';
import { Recipe } from '../user/add-recipe/recipe.model';
import { delay } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  private API_Category = 'http://localhost:3000/category';
  private API_Recipe = 'http://localhost:3000/recipe';

  constructor(private http: HttpClient) {}

  getCategory() {
    return this.http.get<Category[]>(this.API_Category);
  }

  createNewRecipe(recipe: Recipe) {
    return this.http.post<Recipe>(this.API_Recipe, recipe);
  }
}
