import { Component, OnInit } from '@angular/core';
import { Recipe } from '../../shared/recipe.model';
import { RecipeService } from '../../shared/recipe.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass'],
})
export class HomeComponent implements OnInit {
  recipe: Recipe[];
  constructor(private recipeService: RecipeService) {}

  ngOnInit(): void {
    this.recipeService.getRecipe().subscribe((res) => (this.recipe = res));
  }

  deleteRecipe(id: number) {
    this.recipeService
      .deleteRecipe(id)
      .subscribe(() =>
        this.recipeService.getRecipe().subscribe((res) => (this.recipe = res))
      );
  }
}
