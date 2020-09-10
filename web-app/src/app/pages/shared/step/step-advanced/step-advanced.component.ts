import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';

@Component({
  selector: 'app-step-advanced',
  templateUrl: './step-advanced.component.html',
  styleUrls: ['./step-advanced.component.sass'],
})
export class StepAdvancedComponent implements OnInit {
  @Input() stepAdvanced: FormGroup;
  publicado: boolean;
  imageUrl: any;

  @ViewChild('fileInput') inputImage: ElementRef;

  constructor() {}

  ngOnInit(): void {}

  changePublic(event: MatSlideToggleChange) {
    this.publicado = event.checked;
  }

  fileUpload(event): void {
    if (event.target.files && event.target.files[0]) {
      const file = event.target.files[0];

      const reader = new FileReader();
      reader.onload = (e) => (this.imageUrl = reader.result);

      reader.readAsDataURL(file);
    }
  }

  reset() {
    this.imageUrl = this.stepAdvanced.get('imagemPath').reset();
  }
}
