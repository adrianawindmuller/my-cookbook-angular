import { NgModule } from '@angular/core';

import { HeaderComponent } from './header/header.component';
import { SharedModule } from '../shared/shared.module';
import { ContainerComponent } from './container/container.component';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './footer/footer.component';
import { PagesModules } from '../pages/pages.module';
import { SideNavComponent } from '../app-layout/sidenav/side-nav.component';

@NgModule({
  declarations: [
    HeaderComponent,
    ContainerComponent,
    MainComponent,
    FooterComponent,
    SideNavComponent,
  ],
  imports: [SharedModule, PagesModules],
  exports: [ContainerComponent, SideNavComponent],
  providers: [],
})
export class AppLayoutModule {}
