import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [HomeComponent],
  imports: [SharedModule, ToastrModule.forRoot()],
  exports: [HomeComponent],
})
export class PagesModules {}
