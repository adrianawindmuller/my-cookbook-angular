import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { CategoryWithRecipes } from 'src/app/shared/models/category-with-recipes.model';
import { CategoryService } from 'src/app/shared/services/category.service';

@Component({
  selector: 'app-category-recipes',
  templateUrl: './category-recipes.component.html',
})
export class CategoryRecipesComponent implements OnInit, OnDestroy {
  category!: CategoryWithRecipes;
  categoryId!: number;
  sub!: Subscription;

  constructor(
    private categoryService: CategoryService,
    private activeRoute: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.categoryId = this.activeRoute.snapshot.params['id'];

    this.sub = this.categoryService
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
