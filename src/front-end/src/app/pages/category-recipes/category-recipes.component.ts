import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  ActivatedRoute,
  NavigationEnd,
  Router,
  RouterEvent,
} from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject, Subscription } from 'rxjs';
import { filter, takeUntil } from 'rxjs/operators';
import { CategoryWithRecipes } from 'src/app/shared/models/category-with-recipes.model';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
  selector: 'app-category-recipes',
  templateUrl: './category-recipes.component.html',
})
export class CategoryRecipesComponent implements OnInit, OnDestroy {
  category!: CategoryWithRecipes;
  categoryId!: number;
  sub!: Subscription;

  constructor(
    private recipeService: RecipeService,
    private activeRoute: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.categoryId = this.activeRoute.snapshot.params['id'];

    this.sub = this.recipeService
      .getCategoriesByIdWithRecipes(this.categoryId)
      .subscribe(
        (res) => (this.category = res),
        (err) => this.toastr.error(err)
      );
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
