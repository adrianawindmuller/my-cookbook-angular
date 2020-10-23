import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Recipe } from 'src/app/shared/recipe.model';
import { RecipeService } from 'src/app/shared/recipe.service';

@Component({
  selector: 'app-edit-recipe',
  templateUrl: './edit-recipe.component.html',
  styleUrls: ['./edit-recipe.component.sass'],
})
export class EditRecipeComponent implements OnInit {
  recipe: Recipe;
  stepAdvanced: FormGroup;
  stepIngredients: FormGroup;
  stepBasic: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private service: RecipeService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      const id = +params.get('id');
      this.service.getRecipeId(id).subscribe({
        next: (res) => (this.recipe = res),
      });
    });

    this.stepBasic = this.fb.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(60),
        ],
      ],
      category: ['', Validators.required],
      numberPortion: ['', [Validators.required, Validators.maxLength(3)]],
      preparationTime: ['', [Validators.required, Validators.maxLength(3)]],
    });
    this.stepIngredients = this.fb.group({
      ingredients: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(1000),
        ],
      ],
      preparationMode: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(1000),
        ],
      ],
    });
    this.stepAdvanced = this.fb.group({
      public: [''],
      imagemPath: ['', Validators.required],
    });
  }

  joinForms() {
    return {
      ...this.stepBasic.value,
      ...this.stepIngredients.value,
      ...this.stepAdvanced.value,
    };
  }

  SaveEditRecipe() {
    var step = this.joinForms();
    let recipeModel = step as Recipe;
    recipeModel.id = this.recipe.id;
    recipeModel.imagemPath = this.recipe.imagemPath;

    this.service.updateRecipe(recipeModel).subscribe();
  }

  changedFiles(file: string[]) {
    this.recipe.imagemPath = file;
  }
}
