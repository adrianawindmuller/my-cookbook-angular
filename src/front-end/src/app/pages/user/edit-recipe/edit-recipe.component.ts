import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { of } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { RecipeService } from 'src/app/shared/recipe.service';
import { Category } from 'src/app/shared/models/category.model';
import { RecipeRegister } from 'src/app/shared/models/recipe-register.model';

@Component({
  selector: 'app-edit-recipe',
  templateUrl: './edit-recipe.component.html',
  styleUrls: ['./edit-recipe.component.sass'],
})
export class EditRecipeComponent implements OnInit {
  recipeFormEdit: FormGroup;
  publicated: boolean = false;
  category: Category[];
  recipe: RecipeRegister;

  constructor(
    private route: ActivatedRoute,
    private service: RecipeService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.service.getCategory().subscribe((res) => (this.category = res));

    this.route.paramMap.subscribe((params) => {
      const id = +params.get('id');
      this.service.getRecipeIdEdit(id).subscribe((res) => (this.recipe = res));
    });

    this.recipeFormEdit = this.fb.group({
      name: new FormControl(
        { value: '' },
        Validators.compose([
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(60),
        ])
      ),
      categoryId: new FormControl(
        { value: '' },
        Validators.compose([Validators.required])
      ),
      numberPortion: new FormControl(
        { value: '' },
        Validators.compose([Validators.required, Validators.maxLength(3)])
      ),
      preparationTimeInMinutes: new FormControl(
        { value: '' },
        Validators.compose([Validators.required, Validators.maxLength(3)])
      ),
      ingredients: new FormControl(
        { value: '' },
        Validators.compose([
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(1000),
        ])
      ),
      preparationMode: new FormControl(
        { value: '' },
        Validators.compose([
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(1000),
        ])
      ),
      publicated: new FormControl({ value: '' }),
      images: new FormControl(
        { value: '' },
        Validators.compose([Validators.required])
      ),
    });
  }

  SaveEditRecipe() {
    var recipeEdit = this.recipeFormEdit.value;
    let recipeModel = recipeEdit as RecipeRegister;
    recipeModel.id = this.recipe.id;
    recipeModel.userId = 1;
    recipeModel.images = this.recipe.images;
    recipeModel.publicated = this.publicated;

    this.service
      .updateRecipe(recipeModel)
      .pipe(
        catchError((err) => {
          this.toastr.error(err, '');
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
    this.publicated = event.checked;
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
