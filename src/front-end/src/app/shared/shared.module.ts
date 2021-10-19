import { ErrorHandler, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from '../app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RecipeService } from './services/recipe.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarouselComponent } from './carousel/carousel.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RatingComponent } from './rating/rating.component';
import { DialogConfirmComponent } from './dialog-confirm/dialog-confirm.component';
import { ToggleFavoriteComponent } from './toggle-favorite/toggle-favorite.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { FilterRecipePipe } from './pipes/filter-recipe.pipe';
import { LoadingService } from './services/loading.service';
import { NetworkInterceptor } from './services/network.interceptor';
import { CardRecipeComponent } from './card-recipe/card-recipe.component';
import { NavegavateBackComponent } from './navegavate-back/navegavate-back.component';
import { HttpErrorInterceptor } from './services/httpError.interceptor';
import { CategoryService } from './services/category.service';

@NgModule({
  declarations: [
    CarouselComponent,
    RatingComponent,
    DialogConfirmComponent,
    ToggleFavoriteComponent,
    NotFoundComponent,
    FilterRecipePipe,
    CardRecipeComponent,
    NavegavateBackComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    HttpClientModule,
    CommonModule,
    AppRoutingModule,
    BrowserModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule,
  ],
  exports: [
    BrowserAnimationsModule,
    HttpClientModule,
    CommonModule,
    AppRoutingModule,
    BrowserModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    NgbModule,

    //componentes
    CarouselComponent,
    RatingComponent,
    ToggleFavoriteComponent,
    NotFoundComponent,
    FilterRecipePipe,
    CardRecipeComponent,
    NavegavateBackComponent,
  ],
  providers: [
    RecipeService,
    CategoryService,
    LoadingService,
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: NetworkInterceptor, multi: true },
  ],
})
export class SharedModule {}
