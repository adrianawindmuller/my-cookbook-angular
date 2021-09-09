import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryWithRecipes } from 'src/app/shared/models/category-with-recipes.model';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
  selector: 'app-category-recipes',
  templateUrl: './category-recipes.component.html',
})
export class CategoryRecipesComponent implements OnInit {
  category!: CategoryWithRecipes;
  categoryId!: number;

  constructor(
    private recipeService: RecipeService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.categoryId = this.route.snapshot.params['id'];

    this.recipeService
      .getCategoriesByIdWithRecipes(this.categoryId)
      .subscribe((res) => (this.category = res));
  }
}
