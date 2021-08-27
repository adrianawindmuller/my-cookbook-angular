import { Component, OnInit } from '@angular/core';
import { delay } from 'rxjs/operators';
import { LoadingService } from 'src/app/shared/services/loading.service';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css'],
})
export class ContainerComponent implements OnInit {
  loading: boolean = false;

  constructor(private loader: LoadingService) {}

  ngOnInit(): void {
    this.listenToLoading();
  }

  listenToLoading(): void {
    this.loader._loading.pipe(delay(0)).subscribe((res) => {
      this.loading = res;
    });
  }
}
