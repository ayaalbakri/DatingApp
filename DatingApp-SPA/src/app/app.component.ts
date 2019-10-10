import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subscriber } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';
jwtHelper = new JwtHelperService();
constructor(private auth: AuthService) {}
  ngOnInit() {
    const token = localStorage.getItem('token');
    console.log(this.jwtHelper.decodeToken(token),"appppp");
    this.auth.decodedToken = this.jwtHelper.decodeToken(token);
    this.auth.data();
  }
}
