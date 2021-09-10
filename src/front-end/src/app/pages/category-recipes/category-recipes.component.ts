import { Component, OnInit } from '@angular/core';
import {
  ActivatedRoute,
  NavigationEnd,
  Router,
  RouterEvent,
} from '@angular/router';
import { Subject } from 'rxjs';
import { filter, takeUntil } from 'rxjs/operators';
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
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.categoryId = this.activeRoute.snapshot.params['id'];

    this.recipeService
      .getCategoriesByIdWithRecipes(this.categoryId)
      .subscribe((res) => (this.category = res));
  }
}
