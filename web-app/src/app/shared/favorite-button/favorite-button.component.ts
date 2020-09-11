import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Recipe } from '../recipe.model';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-favorite-button',
  templateUrl: './favorite-button.component.html',
  styleUrls: ['./favorite-button.component.sass'],
})
export class FavoriteButtonComponent implements OnInit {
  @Input() recipe: Recipe;

  constructor(private recipeServive: RecipeService) {}

  ngOnInit(): void {}

  toggleFavorite() {
    this.recipe.favorite = !this.recipe.favorite;
    this.recipeServive
      .addFavoriteRecipe(this.recipe)
      .subscribe(() => this.recipeServive.getRecipe());
  }
}
