import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/shared/models/category';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
  selector: 'app-all-categories',
  templateUrl: './all-categories.component.html',
  styleUrls: ['./all-categories.component.css'],
})
export class AllCategoriesComponent implements OnInit {
  categories: Category[] = [];
  constructor(private recipeService: RecipeService) {}

  ngOnInit(): void {
    this.recipeService
      .getCategories()
      .subscribe((res) => (this.categories = res));
  }
}
