import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RecipeService } from '../services/recipe.service';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
})
export class RatingComponent {
  @Input() id!: number;
  @Input() rating!: number;

  constructor(
    private recipeService: RecipeService,
    private toastr: ToastrService
  ) {}

  setRating() {
    this.recipeService.setRating(this.id, this.rating).subscribe((res) => {
      this.toastr.success('Avaliação feita com sucesso!', '', {
        progressBar: true,
        timeOut: 5000,
      });
    });
  }
}
