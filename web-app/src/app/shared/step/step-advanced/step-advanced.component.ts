import {
  Component,
  OnInit,
  Input,
  ViewChild,
  ElementRef,
  Output,
  EventEmitter,
} from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Recipe } from '../../recipe.model';
import { RecipeService } from '../../recipe.service';
import { ImagePath } from './imagePath.model';

@Component({
  selector: 'app-step-advanced',
  templateUrl: './step-advanced.component.html',
  styleUrls: ['./step-advanced.component.sass'],
})
export class StepAdvancedComponent implements OnInit {
  @Input() stepAdvanced: FormGroup;
  @Input() editRecipe: Recipe;
  publicado: boolean;
  imageUrl: string[] = [];

  @Output() changeFile = new EventEmitter<string[]>();

  recipe: Recipe;
  @ViewChild('fileInput') inputImage: ElementRef;
  constructor(private service: RecipeService) {}

  ngOnInit(): void {}

  changePublic(event: MatSlideToggleChange) {
    this.publicado = event.checked;
  }

  fileUpload(event) {
    var files = event.target.files;

    if (files) {
      for (let file of files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.imageUrl.push(e.target.result);
          this.changeFile.emit(this.imageUrl);
        };
        reader.readAsDataURL(file);
      }
    }
  }

  reset(i) {
    this.imageUrl.splice(i, 1);
    this.changeFile.emit(this.imageUrl);
  }
}
