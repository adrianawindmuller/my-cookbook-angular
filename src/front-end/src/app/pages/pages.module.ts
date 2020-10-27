import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';
import { AddRecipeComponent } from './user/add-recipe/add-recipe.component';
import { ViewRecipeComponent } from './user/view-recipe/view-recipe.component';
import { EditRecipeComponent } from './user/edit-recipe/edit-recipe.component';
@NgModule({
  declarations: [HomeComponent, AddRecipeComponent, ViewRecipeComponent, EditRecipeComponent],
  imports: [SharedModule, ToastrModule.forRoot()],
  exports: [],
})
export class PagesModules {}
