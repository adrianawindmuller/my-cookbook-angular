import { Component, Input, OnInit } from '@angular/core';
import { RecipeService } from '../services/recipe.service';

@Component({
  selector: 'app-toggle-favorite',
  templateUrl: './toggle-favorite.component.html',
})
export class ToggleFavoriteComponent {
  @Input() id!: number;
  @Input() isFavorite!: boolean;
  constructor(private recipeService: RecipeService) {}

  toggleFavorite(): void {
    this.isFavorite = !this.isFavorite;
    this.recipeService.toggleFavorite(this.id).subscribe();
  }
}
