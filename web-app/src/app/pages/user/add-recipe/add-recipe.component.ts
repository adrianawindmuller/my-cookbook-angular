import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RecipeService } from '../../shared/recipe.service';

@Component({
  selector: 'app-add-recipe',
  templateUrl: './add-recipe.component.html',
  styleUrls: ['./add-recipe.component.sass'],
})
export class AddRecipeComponent implements OnInit {
  stepBasic: FormGroup;
  stepIngredients: FormGroup;
  stepAdvanced: FormGroup;

  constructor(private fb: FormBuilder, private recipeService: RecipeService) {}

  ngOnInit(): void {
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
          Validators.maxLength(300),
        ],
      ],
      preparationMode: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(300),
        ],
      ],
    });
    this.stepAdvanced = this.fb.group({
      public: [''],
      imagemPath: ['', Validators.required],
    });
  }

  invalidForm() {
    return (
      this.stepBasic.invalid ||
      this.stepIngredients.invalid ||
      this.stepAdvanced.invalid
    );
  }

  joinForms() {
    return {
      ...this.stepBasic.value,
      ...this.stepIngredients.value,
      ...this.stepAdvanced.value,
    };
  }

  createRecipe() {
    if (this.invalidForm) {
      return;
    }
    const newRecipe = this.joinForms();
    this.recipeService.createNewRecipe(newRecipe).subscribe();
  }
}
