import {
  ChangeDetectionStrategy,
  Component,
  OnDestroy,
  OnInit,
} from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import {
  BehaviorSubject,
  combineLatest,
  EMPTY,
  Observable,
  Subscription,
} from 'rxjs';
import { catchError, delay, map, shareReplay, tap } from 'rxjs/operators';
import { CardRecipe } from 'src/app/shared/models/card-recipe.model';
import { Category } from 'src/app/shared/models/category.model';
import { CategoryService } from 'src/app/shared/services/category.service';
import { LoadingService } from 'src/app/shared/services/loading.service';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit, OnDestroy {
  filterName!: string;
  recipes!: CardRecipe[];
  categories$!: Observable<Category[]>;
  isLoading: boolean = false;
  sub!: Subscription;

  private categoryselectedSubject = new BehaviorSubject<number>(0);
  categorySelectedAction$ = this.categoryselectedSubject.asObservable();

  constructor(
    private recipeService: RecipeService,
    private categoryService: CategoryService,
    private loader: LoadingService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.listenToLoading();

    /*
    this.categories$ = this.categoryService.getCategories().pipe(
      catchError((err) => {
        this.toastr.error(err);
        return EMPTY;
      })
    ); */

    this.sub = this.recipeService
      .getRecipes()
      .subscribe((res) => (this.recipes = res));
  }

  filterNameRecipe() {
    if (this.filterName.length) {
      this.sub = this.recipeService
        .filterName(this.filterName)
        .subscribe((res) => (this.recipes = res));
    } else {
      this.sub = this.recipeService
        .getRecipes()
        .subscribe((res) => (this.recipes = res));
    }
  }

  onSelected(Event: any): void {
    var categoryId = parseInt(Event.target.value);
    this.categoryselectedSubject.next(categoryId);
  }

  listenToLoading(): void {
    this.sub = this.loader._loading.pipe(delay(0)).subscribe((res) => {
      this.isLoading = res;
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
