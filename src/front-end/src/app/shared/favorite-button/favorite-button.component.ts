import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-favorite-button',
  templateUrl: './favorite-button.component.html',
  styleUrls: ['./favorite-button.component.sass'],
})
export class FavoriteButtonComponent implements OnInit {
  @Input() favorite: boolean;
  @Input() recipeId: number;

  constructor(private recipeServive: RecipeService) {}

  ngOnInit(): void {}

  toggleFavorite() {
    this.favorite = !this.favorite;
    this.recipeServive
      .ToggleFavoriteRecipe(this.recipeId)
      .subscribe(() => this.recipeServive.getRecipeId(this.recipeId));
  }
}
