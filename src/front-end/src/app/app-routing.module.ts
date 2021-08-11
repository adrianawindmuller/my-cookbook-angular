import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailsRecipeComponent } from './pages/details-recipe/details-recipe.component';
import { HomeComponent } from './pages/home/home.component';
import { SaveRecipeComponent } from './pages/save-recipe/save-recipe.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'add', component: SaveRecipeComponent },
  { path: 'edit/:id', component: SaveRecipeComponent },
  { path: 'recipe/:id', component: DetailsRecipeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}