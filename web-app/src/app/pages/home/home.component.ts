import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass'],
})
export class HomeComponent implements OnInit {
  list = [1, 2, 3, 4, 5, 6];
  constructor() {}

  ngOnInit(): void {}
}
