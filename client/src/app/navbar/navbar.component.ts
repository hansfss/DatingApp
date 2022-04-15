import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {}
  //methods and properties from accountservice.ts are injected via the constructor
  constructor(public accountService: AccountService) { }

  ngOnInit(): void {

  }

  login() {//call to login method from account service
    this.accountService.login(this.model).subscribe(response => {//userDTO gets returned
      console.log(response);
    }, error => {
      console.log(error)
    })
  }

  logout() {
    this.accountService.logout();
  }
}
