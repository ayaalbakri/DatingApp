import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
baseUrl = 'https://localhost:44331/api/Account/';
orthoUrl = 'https://localhost:44331/api/Account/';
constructor(private http: HttpClient) { }
// model: any
decodedToken: any;
 jwtHelper = new JwtHelperService();
//  decodedToken = helper.decodeToken(myRawToken);
//  expirationDate = helper.getTokenExpirationDate(myRawToken);
//  isExpired = helper.isTokenExpired(myRawToken);
loging(model: any ) {

  return this.http.post(this.baseUrl + 'login', model);
  }
  register(data: any) {
    // console.log(data, 'registerregisterregister');
    return this.http.post(this.baseUrl, data).subscribe((res: any) => {
      this.decodedToken = this.jwtHelper.decodeToken(res.token);
      // console.log(this.decodedToken,"decodedTokendecodedToken");
      // console.log(this.jwtHelper.decodeToken(res.token), 'decoced');
      localStorage.setItem('token', res.token);
       localStorage.setItem('tokenExp', this.decodedToken.exp);
       localStorage.setItem('userEmail', this.decodedToken.Email);
 });
  }
  // Ayaghalebali89!  yoyu@gmail.com
  loggedIn() {
    const token = localStorage.getItem('token');
    // console.log(this.jwtHelper.isTokenExpired(token));
    return !this.jwtHelper.isTokenExpired(token);
  }
  data() {
    return this.http.get(this.baseUrl).subscribe((res: any) => {
      console.log(res,"CROSSSSSSSS");
     return res;
 });
  }
}
