import { Component, Input, OnInit } from '@angular/core';
import { CardRecipe } from '../models/card-recipe.model';

@Component({
  selector: 'app-card-recipe',
  templateUrl: './card-recipe.component.html',
})
export class CardRecipeComponent implements OnInit {
  @Input() recipes!: CardRecipe[];
  @Input() filterName!: string;
  constructor() {}

  ngOnInit(): void {}
}
