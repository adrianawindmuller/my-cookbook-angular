import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { ContainerComponent } from './container/container.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [HeaderComponent, ContainerComponent],
  imports: [SharedModule],
  exports: [ContainerComponent],
})
export class AppLayoutModule {}
