import { Component, OnDestroy, OnInit } from '@angular/core';
import { observable, Subscription } from 'rxjs';
import { delay } from 'rxjs/operators';
import { LoadingService } from 'src/app/shared/services/loading.service';

@Component({
  selector: 'app-container',
  templateUrl: './container.component.html',
  styleUrls: ['./container.component.css'],
})
export class ContainerComponent implements OnInit, OnDestroy {
  loading: boolean = false;
  sub!: Subscription;

  constructor(private loader: LoadingService) {}

  ngOnInit(): void {
    this.listenToLoading();
  }

  listenToLoading(): void {
    this.sub = this.loader._loading.pipe(delay(0)).subscribe((res) => {
      this.loading = res;
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}
