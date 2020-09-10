import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { StepBasicComponent } from '../shared/step/step-basic/step-basic.component';
import { RecipeService } from './recipe.service';
import { StepIngredientsComponent } from './step/step-ingredients/step-ingredients.component';
import { StepAdvancedComponent } from './step/step-advanced/step-advanced.component';

@NgModule({
  declarations: [
    StepBasicComponent,
    StepIngredientsComponent,
    StepAdvancedComponent,
  ],
  imports: [SharedModule],
  exports: [
    StepBasicComponent,
    StepIngredientsComponent,
    StepAdvancedComponent,
  ],
  providers: [RecipeService],
})
export class SharedPagesModule {}
