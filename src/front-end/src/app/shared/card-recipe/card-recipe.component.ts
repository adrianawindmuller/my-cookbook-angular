import { Component, Input, OnInit } from '@angular/core';
import { CardRecipe } from '../models/card-recipe.model';
import { Difficulty } from '../models/difficulty.enum';

@Component({
  selector: 'app-card-recipe',
  templateUrl: './card-recipe.component.html',
  styleUrls: ['./card-recipe.component.css'],
})
export class CardRecipeComponent {
  @Input() recipes!: CardRecipe[];
  @Input() filterName!: string;
  difficulty = Difficulty;
}
