import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Category } from '../category.model';
import { RecipeService } from '../../recipe.service';

@Component({
  selector: 'app-step-basic',
  templateUrl: './step-basic.component.html',
  styleUrls: ['./step-basic.component.sass'],
})
export class StepBasicComponent implements OnInit {
  @Input() stepBasic: FormGroup;
  category: Category[];

  constructor(private service: RecipeService) {}

  ngOnInit(): void {
    this.service.getCategory().subscribe((res) => (this.category = res));
  }

  mensagemErroName() {
    return this.stepBasic.get('name').hasError('required')
      ? 'Campo Obrigatório'
      : this.stepBasic.get('name').hasError('minlength')
      ? 'Insira pelo menos 3 caracteres'
      : '';
  }
}
