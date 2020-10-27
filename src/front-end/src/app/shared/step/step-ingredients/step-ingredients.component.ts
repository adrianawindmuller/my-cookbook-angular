import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Recipe } from '../../recipe.model';

@Component({
  selector: 'app-step-ingredients',
  templateUrl: './step-ingredients.component.html',
  styleUrls: ['./step-ingredients.component.sass'],
})
export class StepIngredientsComponent implements OnInit {
  @Input() stepIngredients: FormGroup;
  @Input() editRecipe: Recipe;
  content: string = '';
  contentPreparation: any = 1;
  constructor() {}

  ngOnInit(): void {}

  mensagemErroIngredients() {
    return this.stepIngredients.get('ingredients').hasError('required')
      ? 'Campo Obrigatório'
      : this.stepIngredients.get('ingredients').hasError('minlength')
      ? 'Insira pelo menos 3 caracteres'
      : '';
  }

  mensagemErroPreparation() {
    return this.stepIngredients.get('preparationMode').hasError('required')
      ? ' Campo Obrigatório'
      : this.stepIngredients.get('preparationMode').hasError('minlength')
      ? 'Insira pelo menos 3 caracteres'
      : '';
  }
}
