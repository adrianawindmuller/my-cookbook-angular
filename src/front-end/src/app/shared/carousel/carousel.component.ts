import { Component, Input, OnInit } from '@angular/core';
import {
  NgbCarouselConfig,
  NgbSlideEvent,
  NgbSlideEventSource,
} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styles: ['.image { border-radius: 16px; width: 100%; height: 350px; }'],
})
export class CarouselComponent {
  @Input() images!: string[];
  @Input() name!: string;

  constructor(config: NgbCarouselConfig) {
    config.showNavigationArrows = true;
    config.wrap = false;
    config.pauseOnHover = true;
  }
}
