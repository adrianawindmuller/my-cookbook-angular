import { NgModule } from '@angular/core';

import { HeaderComponent } from './header/header.component';
import { SharedModule } from '../shared/shared.module';
import { ContainerComponent } from './container/container.component';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './footer/footer.component';
import { PagesModules } from '../pages/pages.module';

@NgModule({
  declarations: [
    HeaderComponent,
    ContainerComponent,
    MainComponent,
    FooterComponent,
  ],
  imports: [SharedModule, PagesModules],
  exports: [ContainerComponent],
})
export class AppLayoutModule {}
