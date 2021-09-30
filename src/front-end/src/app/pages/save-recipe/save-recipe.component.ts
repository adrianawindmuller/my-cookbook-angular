import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormArray,
  AbstractControl,
} from '@angular/forms';
import { Category } from 'src/app/shared/models/category.model';
import { SaveRecipe } from 'src/app/shared/models/save-recipe.model';
import { RecipeService } from 'src/app/shared/services/recipe.service';
import { first } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DialogConfirmComponent } from 'src/app/shared/dialog-confirm/dialog-confirm.component';
import { Observable, Subscription } from 'rxjs';

@Component({
  selector: 'app-register-recipe',
  templateUrl: './save-recipe.component.html',
  styleUrls: ['./save-recipe.component.css'],
})
export class SaveRecipeComponent implements OnInit, OnDestroy {
  recipeForm!: FormGroup;
  categories$!: Observable<Category[]>;
  submitted!: boolean;
  isAddMode!: boolean;
  titleName!: string;
  id!: number;
  sub!: Subscription;

  constructor(
    private fb: FormBuilder,
    private recipeService: RecipeService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;

    this.categories$ = this.recipeService.getCategories();

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
      numberPortion: [
        '',
        [Validators.required, Validators.min(1), Validators.max(40)],
      ],
      preparationTimeInMinutes: [
        '',
        [Validators.required, Validators.min(10), Validators.max(600)],
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
      images: this.fb.array([], Validators.required),
      published: [true],
    });

    if (!this.isAddMode) {
      this.sub = this.recipeService
        .getRecipeEditId(this.id)
        .pipe(first())
        .subscribe((x) => {
          this.recipeForm.patchValue(x);

          for (const image of x.images) {
            this.addImagesInForm(image);
          }
        });

      this.titleName = 'Editar';
    }
  }

  get images(): FormArray {
    return this.form.images as FormArray;
  }

  get form(): { [key: string]: AbstractControl } {
    return this.recipeForm.controls;
  }

  addImagesInForm(image: string) {
    const imagesForm = this.fb.control(image, [Validators.required]);
    this.images.push(imagesForm);
  }

  onSubmit() {
    this.submitted = true;

    if (!this.recipeForm.valid) {
      return;
    }

    if (this.isAddMode) {
      this.registerRecipe();
    } else {
      this.updateRecipe();
    }

    this.submitted = false;
  }

  registerRecipe(): void {
    const newRecipe = this.recipeForm.value;
    newRecipe.categoryId = parseInt(newRecipe.categoryId);

    let recipeModel = newRecipe as SaveRecipe;

    this.sub = this.recipeService.postRecipe(recipeModel).subscribe(() => {
      this.router.navigate(['./home']);
      this.toastr.success('Receita adicionada com sucesso!', '', {
        progressBar: true,
        timeOut: 5000,
      });
    });
  }

  updateRecipe(): void {
    const newRecipe = this.recipeForm.value;
    newRecipe.categoryId = parseInt(newRecipe.categoryId);

    let recipeModel = newRecipe as SaveRecipe;

    this.sub = this.recipeService
      .putRecipe(this.id, recipeModel)
      .subscribe(() => {
        this.router.navigate(['./recipe', this.id]);
        this.toastr.success('Receita atualizada com sucesso!', '', {
          progressBar: true,
          timeOut: 5000,
        });
      });
  }

  fileUploadImage(event: any): void {
    var files = event.target.files;

    if (files) {
      for (let file of files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.addImagesInForm(e.target.result);
        };
        reader.readAsDataURL(file);
      }
    }
  }

  removeImage(index: number): void {
    this.images.removeAt(index);
    this.images.markAsTouched();
  }

  messengeErrorName(): string {
    const name = this.form.name;

    if (name.hasError('required')) {
      return 'Campo Obrigatório';
    }

    if (name.hasError('minlength')) {
      return 'Insira pelo menos 5 caracteres';
    }

    return '';
  }

  messengeErrorNumberPortion(): string {
    const numberPortion = this.form.numberPortion;

    if (numberPortion.hasError('required')) {
      return 'Campo Obrigatório';
    }

    if (numberPortion.hasError('min')) {
      return 'Insira no mínimo 1 porção.';
    }

    if (numberPortion.hasError('max')) {
      return 'Insira no máximo 40 porções.';
    }
    return '';
  }

  messengeErrorPreparationTimeInMinutes(): string {
    const preparation = this.form.preparationTimeInMinutes;

    if (preparation.hasError('required')) {
      return 'Campo Obrigatório';
    }

    if (preparation.hasError('min')) {
      return 'Insira no mínimo 10 minutos.';
    }

    if (preparation.hasError('max')) {
      return 'Insira no máximo 600 minutos';
    }

    return '';
  }

  messengeErrorIngredients(): string {
    const ingredients = this.form.ingredients;

    if (ingredients.hasError('required')) {
      return 'Campo Obrigatório';
    }

    if (ingredients.hasError('minlength')) {
      return 'Insira pelo menos 5 caracteres';
    }

    return '';
  }

  messengeErrorPreparationMode(): string {
    const preparationMode = this.form.preparationMode;

    if (preparationMode.hasError('required')) {
      return 'Campo Obrigatório';
    }

    if (preparationMode.hasError('minlength')) {
      return 'Insira pelo menos 5 caracteres';
    }

    return '';
  }

  navegateBack() {
    if (this.recipeForm.dirty) {
      this.openModalConfirmeNavegateBack();
    } else {
      this.location.back();
    }
  }

  openModalConfirmeNavegateBack(): void {
    let modalRef = this.modalService.open(DialogConfirmComponent);
    modalRef.componentInstance.messenge = `Você alterou alguns dados! Tem certeza que deseja voltar?`;
    modalRef.componentInstance.nameAction = 'Voltar';
    modalRef.result.then((res) => {
      this.location.back();
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
