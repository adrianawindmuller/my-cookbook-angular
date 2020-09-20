import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from './step/category.model';
import { Recipe } from './recipe.model';
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
    recipe.ingredients = this.changeString(recipe.ingredients);
    recipe.preparationMode = this.changeString(recipe.preparationMode);
    recipe.imagemPath = recipe.imagemPath.replace('C:\\fakepath\\', 'assets/');
    return this.http.post<Recipe>(this.API_Recipe, recipe);
  }

  changeString(ingredients: string) {
    let ingredientesBefore = ingredients.split('\n').filter((i) => i);

    let ingredientsAfter = '<ul>';
    ingredientesBefore.forEach((item) => {
      ingredientsAfter += `<li>${item}</li>`;
    });
    ingredientsAfter += '</ul>';
    return ingredientsAfter;
  }

  getRecipe() {
    return this.http.get<Recipe[]>(this.API_Recipe);
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
}
