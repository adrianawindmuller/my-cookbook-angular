import { Component, OnDestroy, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { EMPTY, Subscription } from 'rxjs';
import { catchError, delay } from 'rxjs/operators';
import { CardRecipe } from 'src/app/shared/models/card-recipe.model';
import { LoadingService } from 'src/app/shared/services/loading.service';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit, OnDestroy {
  filterName!: string;
  recipes!: CardRecipe[];
  isLoading: boolean = false;
  sub!: Subscription;
  errorMessage!: string;

  constructor(
    private recipeService: RecipeService,
    private loader: LoadingService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.listenToLoading();
    this.sub = this.recipeService.getRecipes().subscribe(
      (res) => (this.recipes = res),
      (error) => this.toastr.error(error)
    );
  }

  listenToLoading(): void {
    this.sub = this.loader._loading.pipe(delay(0)).subscribe((res) => {
      this.isLoading = res;
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
