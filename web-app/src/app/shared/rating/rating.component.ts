import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Recipe } from '../recipe.model';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.sass'],
})
export class RatingComponent implements OnInit {
  @Input() rating: number;
  @Output() ratingUpdated = new EventEmitter();

  starMax: Number = 5;
  ratingArray = [];

  constructor(private recipeService: RecipeService) {}

  ngOnInit(): void {
    for (let index = 0; index < this.starMax; index++) {
      this.ratingArray.push(index);
    }
  }

  ratingClick(rating: number) {
    this.ratingUpdated.emit(rating);
  }

  showIcone(index: number) {
    if (this.rating >= index + 1) {
      return 'star';
    } else {
      return 'star_outline';
    }
  }
}
