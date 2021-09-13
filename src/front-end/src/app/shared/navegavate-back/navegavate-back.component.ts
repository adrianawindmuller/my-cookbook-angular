import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navegavate-back',
  templateUrl: './navegavate-back.component.html',
})
export class NavegavateBackComponent implements OnInit {
  constructor(private location: Location) {}

  ngOnInit(): void {}

  navegateBack() {
    this.location.back();
  }
}
