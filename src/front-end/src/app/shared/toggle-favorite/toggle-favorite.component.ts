import { Component, Input, OnInit } from '@angular/core';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-toggle-favorite',
  templateUrl: './toggle-favorite.component.html',
})
export class ToggleFavoriteComponent implements OnInit {
  @Input() id!: number;
  @Input() isFavorite!: boolean;
  constructor(private recipeService: RecipeService) {}

  ngOnInit(): void {}

  toggleFavorite(): void {
    this.isFavorite = !this.isFavorite;
    this.recipeService.toggleFavorite(this.id).subscribe();
  }
}
