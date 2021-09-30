import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
})
export class NotFoundComponent {
  @Input() messageNotFound!: string;
  @Input() messageAddRecipe!: string;
}
