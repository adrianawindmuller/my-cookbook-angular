import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-dialog-confirm',
  templateUrl: './dialog-confirm.component.html',
})
export class DialogConfirmComponent implements OnInit {
  @Input() messenge!: string;
  @Input() nameAction!: string;

  constructor(public modal: NgbActiveModal) {}

  ngOnInit(): void {}
}
