import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { DialogConfirmComponent } from 'src/app/shared/dialog-confirm/dialog-confirm.component';
import { RecipeViewDetails } from 'src/app/shared/models/recipe-view-details.model';
import { RecipeService } from 'src/app/shared/services/recipe.service';

@Component({
  selector: 'app-edit-recipe',
  templateUrl: './details-recipe.component.html',
})
export class DetailsRecipeComponent implements OnInit {
  recipe!: RecipeViewDetails;
  htmlIngredients!: string;
  htmlPreparationMode!: string;

  constructor(
    private recipeService: RecipeService,
    private route: ActivatedRoute,
    private modalService: NgbModal,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      const id = +params['id'];
      this.getRecipe(id);
    });
  }

  getRecipe(id: number): void {
    this.recipeService.getRecipeId(id).subscribe((res) => {
      this.recipe = res;
      this.htmlIngredients = this.changeStringinHtml(res.ingredients, true);
      this.htmlPreparationMode = this.changeStringinHtml(
        res.preparationMode,
        false
      );
    });
  }

  changeStringinHtml(text: string, isIngredients: boolean): string {
    let textBefore = text.split('\n').filter((i) => i);
    let textAfter = '';

    isIngredients ? (textAfter = '<ul>') : (textAfter = '<ol>');
    textBefore.forEach((item) => {
      textAfter += `<li>${item}</li>`;
    });

    return textAfter;
  }

  openModalDeleteRecipe(id: number): void {
    let modalRef = this.modalService.open(DialogConfirmComponent);
    modalRef.componentInstance.messenge = `Tem certeza que deseja excluir a receita ${this.recipe.name}?`;
    modalRef.result.then((res) => {
      this.deleteRecipe(id);
    });
  }

  deleteRecipe(id: number): void {
    this.recipeService.deleteRecipeId(id).subscribe((res) => {
      this.router.navigate(['./home']);
      this.toastr.success('Receita deletada com sucesso!', '', {
        progressBar: true,
        timeOut: 5000,
      });
    });
  }
}
