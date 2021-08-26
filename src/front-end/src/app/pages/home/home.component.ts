import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable, combineLatest } from 'rxjs';
import { startWith } from 'rxjs/operators';
import { CardRecipe } from 'src/app/shared/models/card-recipe.model';
import { RecipeService } from 'src/app/shared/recipe.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  filterName!: string;
  recipes!: CardRecipe[];
  show = true;

  constructor(private recipeService: RecipeService) {}

  ngOnInit(): void {
    this.recipeService.getRecipes().subscribe((res) => (this.recipes = res));
  }
}
