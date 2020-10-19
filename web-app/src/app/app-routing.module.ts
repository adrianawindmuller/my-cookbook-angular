import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AddRecipeComponent } from './pages/user/add-recipe/add-recipe.component';
import { EditRecipeComponent } from './pages/user/edit-recipe/edit-recipe.component';
import { ViewRecipeComponent } from './pages/user/view-recipe/view-recipe.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'send-recipe', component: AddRecipeComponent },
  { path: 'recipe/:id', component: ViewRecipeComponent },
  { path: 'recipe/:id/edit', component: EditRecipeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
