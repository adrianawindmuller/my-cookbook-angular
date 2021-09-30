import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from 'src/app/shared/models/category.model';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
  categories$: Observable<Category[]> | undefined;

  constructor(private recipeService: RecipeService) {}

  ngOnInit(): void {
    this.categories$ = this.recipeService.getCategories();
  }
}
