import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/shared/models/category.model';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
  categories: Category[] = [];
  constructor(private recipeService: RecipeService) {}

  ngOnInit(): void {
    this.recipeService
      .getCategories()
      .subscribe((res) => (this.categories = res));
  }
}
