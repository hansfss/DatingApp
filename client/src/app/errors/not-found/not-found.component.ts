import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-not-found',
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css']
})
export class NotFoundComponent implements OnInit {
  status = false;

  constructor() {}

  ngOnInit(): void {
  }

  logInStatus() {
    this.status = !this.status;
  }
}
