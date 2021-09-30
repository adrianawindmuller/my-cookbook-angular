import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navegavate-back',
  templateUrl: './navegavate-back.component.html',
})
export class NavegavateBackComponent {
  constructor(private location: Location) {}

  navegateBack() {
    this.location.back();
  }
}
