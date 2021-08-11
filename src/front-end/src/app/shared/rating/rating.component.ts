import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RecipeService } from '../recipe.service';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
})
export class RatingComponent implements OnInit {
  @Input() id!: number;
  @Input() rating!: number;

  constructor(
    private recipeService: RecipeService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {}

  setRating() {
    this.recipeService.setRating(this.id, this.rating).subscribe((res) => {
      this.toastr.success('Avaliação feita com sucesso!', '', {
        progressBar: true,
        timeOut: 5000,
      });
    });
  }
}
