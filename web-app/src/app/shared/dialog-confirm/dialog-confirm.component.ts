import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-dialog-confirm',
  templateUrl: './dialog-confirm.component.html',
  styleUrls: ['./dialog-confirm.component.sass'],
})
export class DialogConfirmComponent implements OnInit {
  constructor(public dialogRef: MatDialogRef<DialogConfirmComponent>) {}

  ngOnInit(): void {}
}
