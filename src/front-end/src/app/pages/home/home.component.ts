import { Component, OnInit } from '@angular/core';
import { delay } from 'rxjs/operators';
import { CardRecipe } from 'src/app/shared/models/card-recipe.model';
import { LoadingService } from 'src/app/shared/services/loading.service';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  filterName!: string;
  recipes!: CardRecipe[];
  isLoading: boolean = false;

  constructor(
    private recipeService: RecipeService,
    private loader: LoadingService
  ) {}

  ngOnInit(): void {
    this.listenToLoading();
    this.recipeService.getRecipes().subscribe((res) => (this.recipes = res));
  }

  listenToLoading(): void {
    this.loader._loading.pipe(delay(0)).subscribe((res) => {
      this.isLoading = res;
    });
  }
}
