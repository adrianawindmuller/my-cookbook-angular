import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppLayoutModule } from './app-layout/app-layout.module';
import { SharedModule } from './shared/shared.module';
import { PagesModule } from './pages/pages.module';

@NgModule({
  declarations: [AppComponent],
  imports: [AppLayoutModule, SharedModule, PagesModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
