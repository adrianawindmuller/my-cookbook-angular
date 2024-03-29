import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { SharedModule } from '../shared/shared.module';
import { ToastrModule } from 'ngx-toastr';
import { DetailsRecipeComponent } from './details-recipe/details-recipe.component';
import { SaveRecipeComponent } from './save-recipe/save-recipe.component';
import { AllCategoriesComponent } from './all-categories/all-categories.component';
import { CategoryRecipesComponent } from './category-recipes/category-recipes.component';
import { AboutComponent } from './about/about.component';

@NgModule({
  declarations: [HomeComponent, SaveRecipeComponent, DetailsRecipeComponent, AllCategoriesComponent, CategoryRecipesComponent, AboutComponent],
  imports: [CommonModule, SharedModule, ToastrModule.forRoot()],
})
export class PagesModule {}
