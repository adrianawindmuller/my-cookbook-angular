import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatSliderModule } from '@angular/material/slider';
import { FlexLayoutModule } from '@angular/flex-layout';

import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

import { MatRadioModule } from '@angular/material/radio';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';

import { MatCheckboxModule } from '@angular/material/checkbox';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatToolbarModule } from '@angular/material/toolbar';

import { MatDialogModule } from '@angular/material/dialog';

import { ScrollingModule } from '@angular/cdk/scrolling';
import { MatMenuModule } from '@angular/material/menu';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from '../app-routing.module';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatStepperModule } from '@angular/material/stepper';
import { MatSelectModule } from '@angular/material/select';
import { HttpClientModule } from '@angular/common/http';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatRippleModule } from '@angular/material/core';

import { RecipeService } from '../shared/recipe.service';
import { StepBasicComponent } from '../shared/step/step-basic/step-basic.component';
import { StepIngredientsComponent } from './step/step-ingredients/step-ingredients.component';
import { StepAdvancedComponent } from './step/step-advanced/step-advanced.component';
import { FavoriteButtonComponent } from '../shared/favorite-button/favorite-button.component';

@NgModule({
  declarations: [
    StepBasicComponent,
    StepIngredientsComponent,
    StepAdvancedComponent,
    FavoriteButtonComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserAnimationsModule,
    BrowserModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MatSliderModule,
    FlexLayoutModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatRadioModule,
    MatCheckboxModule,
    MatDialogModule,
    AppRoutingModule,
    MatStepperModule,
    MatSelectModule,
    MatSlideToggleModule,
  ],
  exports: [
    HttpClientModule,
    BrowserAnimationsModule,
    BrowserModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MatSliderModule,
    FlexLayoutModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatRadioModule,
    MatDividerModule,
    MatListModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatDialogModule,
    ScrollingModule,
    MatMenuModule,
    AppRoutingModule,
    DragDropModule,
    MatSidenavModule,
    MatExpansionModule,
    MatStepperModule,
    MatSelectModule,
    MatSlideToggleModule,
    MatRippleModule,

    // componentes
    StepBasicComponent,
    StepIngredientsComponent,
    StepAdvancedComponent,
    FavoriteButtonComponent,
  ],
  providers: [RecipeService],
})
export class SharedModule {}
