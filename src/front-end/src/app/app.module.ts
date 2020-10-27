import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { AppLayoutModule } from './app-layout/app-layout.module';
import { PagesModules } from './pages/pages.module';
@NgModule({
  declarations: [AppComponent],
  imports: [SharedModule, AppRoutingModule, AppLayoutModule, PagesModules],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
