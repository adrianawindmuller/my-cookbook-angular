import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/shared/models/category';
import { CategoryWithRecipes } from 'src/app/shared/models/category-with-recipes';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
  selector: 'app-all-categories',
  templateUrl: './all-categories.component.html',
  styleUrls: ['./all-categories.component.css'],
})
export class AllCategoriesComponent implements OnInit {
  categories: CategoryWithRecipes[] = [];
  constructor(private recipeService: RecipeService) {}

  ngOnInit(): void {
    this.recipeService
      .getCategoriesWithRecipes()
      .subscribe((res) => (this.categories = res));
  }
}
