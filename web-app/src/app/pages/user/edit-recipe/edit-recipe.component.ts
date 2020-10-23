import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
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
    private router: Router,
    private service: RecipeService,
    private fb: FormBuilder,
    private toastr: ToastrService
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
      images: ['', Validators.required],
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
    recipeModel.images = this.recipe.images;

    this.service
      .updateRecipe(recipeModel)
      .pipe(
        catchError((err) => {
          this.toastr.error(err, '', {
            progressBar: true,
          });
          return of();
        }),
        finalize(() => {
          this.toastr.success('Receita atualizada com sucesso!👏', '', {
            progressBar: true,
            timeOut: 5000,
          });
        })
      )
      .subscribe();
  }

  changedFiles(file: string[]) {
    this.recipe.images = file;
  }
}
