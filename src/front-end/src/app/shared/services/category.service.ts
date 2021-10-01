import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryWithRecipes } from '../models/category-with-recipes.model';
import { Category } from '../models/category.model';
import { AppEnviroment } from './app-environment';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
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
}
