import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RecipeService } from '../../../shared/recipe.service';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { Router } from '@angular/router';
import { Category } from 'src/app/shared/models/category.model';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { RecipeRegister } from 'src/app/shared/models/recipe-register.model';
@Component({
  selector: 'app-add-recipe',
  templateUrl: './add-recipe.component.html',
  styleUrls: ['./add-recipe.component.sass'],
})
export class AddRecipeComponent implements OnInit {
  recipeForm: FormGroup;
  images: string[] = [];
  publicado: boolean = false;
  category: Category[];

  constructor(
    private fb: FormBuilder,
    private recipeService: RecipeService,
    private toastr: ToastrService,
    private route: Router,
    private service: RecipeService
  ) {}

  ngOnInit(): void {
    this.service.getCategory().subscribe((res) => (this.category = res));

    this.recipeForm = this.fb.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(60),
        ],
      ],
      categoryId: ['', Validators.required],
      numberPortion: ['', [Validators.required, Validators.maxLength(3)]],
      preparationTimeInMinutes: [
        '',
        [Validators.required, Validators.maxLength(3)],
      ],
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
      images: ['', Validators.required],
    });
  }

  createRecipe() {
    if (!this.recipeForm.valid) {
      return;
    }
    const newRecipe = this.recipeForm.value;

    let recipeModel = newRecipe as RecipeRegister;
    recipeModel.images = this.images;
    recipeModel.userId = 1;
    recipeModel.publicated = this.publicado;

    this.recipeService
      .createNewRecipe(recipeModel)
      .pipe(
        catchError((err) => {
          console.log(JSON.stringify(err));
          this.toastr.error(err, '', {
            progressBar: true,
          });
          return of();
        }),
        finalize(() => {
          this.route.navigate(['./home']);
          this.toastr.success('Receita adicionada com sucesso!👏', '', {
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

  fileUploadImage(event) {
    var files = event.target.files;

    if (files) {
      for (let file of files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.images.push(e.target.result);
        };
        reader.readAsDataURL(file);
      }
    }
  }

  resetImage(i) {
    this.images.splice(i, 1);
  }

  mensagemErroName() {
    return this.recipeForm.get('name').hasError('required')
      ? 'Campo Obrigatório'
      : this.recipeForm.get('name').hasError('minlength')
      ? 'Insira pelo menos 3 caracteres'
      : '';
  }

  mensagemErroIngredients() {
    return this.recipeForm.get('ingredients').hasError('required')
      ? 'Campo Obrigatório'
      : this.recipeForm.get('ingredients').hasError('minlength')
      ? 'Insira pelo menos 3 caracteres'
      : '';
  }

  mensagemErroPreparation() {
    return this.recipeForm.get('preparationMode').hasError('required')
      ? ' Campo Obrigatório'
      : this.recipeForm.get('preparationMode').hasError('minlength')
      ? 'Insira pelo menos 3 caracteres'
      : '';
  }
}
