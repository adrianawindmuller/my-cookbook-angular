import {
  Component,
  OnInit,
  ChangeDetectionStrategy,
  Input,
} from '@angular/core';
import { lyl, StyleRenderer } from '@alyle/ui';

const STYLES = () => {
  return {
    carousel: () => lyl`{
      margin: auto
      // responsive
      max-width: 1000px
      height: 50vh
      min-height: 220px
      max-height: 400px
    }`,
    carouselHome: () => lyl`{
      margin: auto
      // responsive
      max-width: 300px
      height: 25vh
    }`,
    carouselItem: () => lyl`{
      display: flex
      text-align: center
      justify-content: flex-end
      align-items: center
      height: 100%
      flex-direction: column
      padding: 1em 1em 48px
      box-sizing: border-box
      color: #fff
      &:nth-child(3) {
        color: #2b2b2b
      }
    }`,
  };
};

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  preserveWhitespaces: false,
  providers: [StyleRenderer],
})
export class CarouselComponent implements OnInit {
  @Input() imagePath: string[];
  @Input() sizeCard: boolean;

  readonly classes = this.sRenderer.renderSheet(STYLES);

  constructor(private sRenderer: StyleRenderer) {}

  ngOnInit(): void {}
}
