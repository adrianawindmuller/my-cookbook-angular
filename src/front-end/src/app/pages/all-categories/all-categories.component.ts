import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { EMPTY, Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Category } from 'src/app/shared/models/category.model';
import { CategoryService } from 'src/app/shared/services/category.service';
@Component({
  selector: 'app-all-categories',
  templateUrl: './all-categories.component.html',
})
export class AllCategoriesComponent implements OnInit {
  categories$: Observable<Category[]> | undefined;

  constructor(
    private categoryService: CategoryService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.categories$ = this.categoryService.getCategories().pipe(
      catchError((err) => {
        this.toastr.error(err);
        return EMPTY;
      })
    );
  }
}
