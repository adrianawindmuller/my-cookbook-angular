import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';
import { AddRecipeComponent } from './user/add-recipe/add-recipe.component';
@NgModule({
  declarations: [HomeComponent, AddRecipeComponent],
  imports: [SharedModule, ToastrModule.forRoot()],
  exports: [],
})
export class PagesModules {}
