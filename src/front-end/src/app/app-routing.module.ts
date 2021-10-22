import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './pages/about/about.component';
import { AllCategoriesComponent } from './pages/all-categories/all-categories.component';
import { CategoryRecipesComponent } from './pages/category-recipes/category-recipes.component';
import { DetailsRecipeComponent } from './pages/details-recipe/details-recipe.component';
import { HomeComponent } from './pages/home/home.component';
import { SaveRecipeComponent } from './pages/save-recipe/save-recipe.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'about', component: AboutComponent },
  { path: 'add', component: SaveRecipeComponent },
  { path: 'edit/:id', component: SaveRecipeComponent },
  { path: 'recipe/:id', component: DetailsRecipeComponent },
  { path: 'categories', component: AllCategoriesComponent },
  { path: 'categories/:id', component: CategoryRecipesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
