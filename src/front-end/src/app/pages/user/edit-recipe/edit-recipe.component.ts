import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { Recipe } from 'src/app/shared/recipe.model';
import { RecipeService } from 'src/app/shared/recipe.service';
import { Category } from 'src/app/shared/step/category.model';

@Component({
  selector: 'app-edit-recipe',
  templateUrl: './edit-recipe.component.html',
  styleUrls: ['./edit-recipe.component.sass'],
})
export class EditRecipeComponent implements OnInit {
  recipeFormEdit: FormGroup;
  // images: string[] = [];
  publicado: boolean;
  category: Category[];
  recipe: Recipe;

  constructor(
    private route: ActivatedRoute,
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

    this.service.getCategory().subscribe((res) => (this.category = res));

    this.recipeFormEdit = this.fb.group({
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
      public: [''],
      images: ['', Validators.required],
    });
  }

  SaveEditRecipe() {
    var recipeEdit = this.recipeFormEdit.value;
    let recipeModel = recipeEdit as Recipe;
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

  changePublic(event: MatSlideToggleChange) {
    this.publicado = event.checked;
  }

  fileUploadEditImage(event) {
    var files = event.target.files;

    if (files) {
      for (let file of files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.recipe.images.push(e.target.result);
        };
        reader.readAsDataURL(file);
      }
    }
  }

  resetEditImage(i) {
    this.recipe.images.splice(i, 1);
  }

  mensagemErroName() {
    return this.recipeFormEdit.get('name').hasError('required')
      ? 'Campo Obrigatório'
      : this.recipeFormEdit.get('name').hasError('minlength')
      ? 'Insira pelo menos 3 caracteres'
      : '';
  }

  mensagemErroIngredients() {
    return this.recipeFormEdit.get('ingredients').hasError('required')
      ? 'Campo Obrigatório'
      : this.recipeFormEdit.get('ingredients').hasError('minlength')
      ? 'Insira pelo menos 3 caracteres'
      : '';
  }

  mensagemErroPreparation() {
    return this.recipeFormEdit.get('preparationMode').hasError('required')
      ? ' Campo Obrigatório'
      : this.recipeFormEdit.get('preparationMode').hasError('minlength')
      ? 'Insira pelo menos 3 caracteres'
      : '';
  }
}
