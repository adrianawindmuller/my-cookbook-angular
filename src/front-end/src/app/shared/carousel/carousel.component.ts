import { Component, Input, OnInit } from '@angular/core';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styles: ['.image { border-radius: 16px; width: 100%; height: 350px; }'],
})
export class CarouselComponent implements OnInit {
  @Input() images!: string[];
  @Input() name!: string;

  constructor(config: NgbCarouselConfig) {
    config.showNavigationArrows = true;
    config.wrap = true;
    config.pauseOnHover = true;
  }

  ngOnInit(): void {}
}
