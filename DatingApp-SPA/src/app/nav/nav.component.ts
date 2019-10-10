import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { JwtHelperService } from '@auth0/angular-jwt';
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],

})
export class NavComponent implements OnInit {
model: any = {};
userEmail: string;
  result: any;
  constructor(private auth: AuthService, public alertify: AlertifyService) { }

  ngOnInit() {
    if (this.userEmail) {
    this.userEmail = this.auth.decodedToken.Email;
    }
  }
  login() {
 this.result = this.auth.loging(this.model).subscribe((res: any) => {
 this.alertify.success('logged in successfully');
  console.log(this.alertify, 'alertttttt');
   localStorage.setItem('token', res.token);
   localStorage.setItem('tokenExp', res.exp);
   localStorage.setItem('userEmail', res.userInf.email);
   this.userEmail = this.auth.decodedToken.Email;
   // console.log(this.userEmail,"this.userEmailthis.userEmailthis.userEmail");

}, error => {
  this.alertify.error(error.error);
console.log(error);

});
console.log(this.result , 'this.result this.result this.result this.result ');
  }
  loggedIn() {
   return this.auth.loggedIn();
  }
  loggedOut() {
    console.log("LLLLLLLLLLLLLogOOOOOOOOOOut");
   localStorage.removeItem('token');
  }
}
