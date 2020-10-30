import { Component, OnInit } from '@angular/core';
import { Recipe } from 'src/app/shared/recipe.model';
import { RecipeService } from 'src/app/shared/recipe.service';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/shared/category.model';
import { RecipeDetails } from 'src/app/shared/recipe-details.model';

@Component({
  selector: 'app-view-recipe',
  templateUrl: './view-recipe.component.html',
  styleUrls: ['./view-recipe.component.sass'],
})
export class ViewRecipeComponent implements OnInit {
  recipe: RecipeDetails;
  ingredientsHtml: string;
  preparoModeHtml: string;
  category: Category;

  constructor(
    private recipeService: RecipeService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const id = +params.get('id');
      this.recipeService.getRecipeId(id).subscribe({
        next: (recipe) => {
          this.recipe = recipe;
          this.ingredientsHtml = this.changeString(this.recipe.ingredients);
          this.preparoModeHtml = this.changeString(this.recipe.preparationMode);
        },
      });
    });
  }

  onRatingChanged(rating: number) {
    this.recipe.rating = rating;
    // this.recipeService.addRating(this.recipe).subscribe();
  }

  changeString(ingredients: string) {
    let ingredientesBefore = ingredients.split('\\n' || '\n').filter((i) => i);

    let ingredientsAfter = '<ul>';
    ingredientesBefore.forEach((item) => {
      ingredientsAfter += `<li>${item}</li>`;
    });
    ingredientsAfter += '</ul>';
    return ingredientsAfter;
  }
}
