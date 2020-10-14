import { Component, OnInit } from '@angular/core';
import { Recipe } from '../../shared/recipe.model';
import { RecipeService } from '../../shared/recipe.service';
import { Observable, of } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { DialogConfirmComponent } from 'src/app/shared/dialog-confirm/dialog-confirm.component';
import { ToastrService } from 'ngx-toastr';
import { catchError, finalize } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass'],
})
export class HomeComponent implements OnInit {
  recipe: Recipe[];

  constructor(
    private recipeService: RecipeService,
    public dialog: MatDialog,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.recipeService.getRecipe().subscribe((res) => (this.recipe = res));
  }

  deleteRecipe(id: number) {
    const dialogRef = this.dialog.open(DialogConfirmComponent, {
      width: '300px',
    });

    dialogRef.afterClosed().subscribe((excluir) => {
      if (excluir) {
        this.recipeService
          .deleteRecipe(id)
          .pipe(
            catchError((err) => {
              this.toastr.error(err, '', {
                progressBar: true,
              });
              return of();
            }),
            finalize(() => {
              this.toastr.success('Receita excluida com sucesso!', '', {
                progressBar: true,
              });
            })
          )
          .subscribe(() =>
            this.recipeService
              .getRecipe()
              .subscribe((res) => (this.recipe = res))
          );
      }
    });
  }
}
