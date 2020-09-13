import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { AddRecipeComponent } from './pages/user/add-recipe/add-recipe.component';
import { ViewRecipeComponent } from './pages/user/view-recipe/view-recipe.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'enviar-receita', component: AddRecipeComponent },
  { path: 'receita/:id', component: ViewRecipeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
