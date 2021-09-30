import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-card-details-recipe',
  templateUrl: './card-details-recipe.component.html',
})
export class CardDetailsRecipeComponent {
  @Input() icon!: string;
  @Input() name!: string;
  @Input() result: any;
}
