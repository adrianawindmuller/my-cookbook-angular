import {
  Component,
  OnInit,
  Input,
  ViewChild,
  ElementRef,
  Output,
  EventEmitter,
} from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { MatSlideToggleChange } from '@angular/material/slide-toggle';
import { Recipe } from '../../recipe.model';
import { RecipeService } from '../../recipe.service';

@Component({
  selector: 'app-step-advanced',
  templateUrl: './step-advanced.component.html',
  styleUrls: ['./step-advanced.component.sass'],
})
export class StepAdvancedComponent implements OnInit {
  @Input() stepAdvanced: FormGroup;
  @Input() recipe: Recipe;
  publicado: boolean;
  imagemUrl: string[] = [];

  @Output() changeFile = new EventEmitter<string[]>();
  @ViewChild('fileInput') inputImage: ElementRef;
  constructor(private service: RecipeService) {}

  ngOnInit(): void {}

  changePublic(event: MatSlideToggleChange) {
    this.publicado = event.checked;
  }

  fileUploadImage(event) {
    var files = event.target.files;

    if (files) {
      for (let file of files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.imagemUrl.push(e.target.result);
          this.changeFile.emit(this.imagemUrl);
        };
        reader.readAsDataURL(file);
      }
    }
  }

  resetImage(i) {
    this.imagemUrl.splice(i, 1);
    this.changeFile.emit(this.imagemUrl);
  }

  fileUploadEditImage(event) {
    var files = event.target.files;

    if (files) {
      for (let file of files) {
        let reader = new FileReader();
        reader.onload = (e: any) => {
          this.recipe.imagemPath.push(e.target.result);
          this.changeFile.emit(this.recipe.imagemPath);
        };
        reader.readAsDataURL(file);
      }
    }
  }

  resetEditImage(i) {
    this.recipe.imagemPath.splice(i, 1);
    this.changeFile.emit(this.recipe.imagemPath);
  }
}
