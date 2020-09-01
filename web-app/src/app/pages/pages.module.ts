import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [],
  imports: [SharedModule, ToastrModule.forRoot()],
  exports: [],
})
export class PagesModules {}
