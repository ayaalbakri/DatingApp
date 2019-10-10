import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private http: HttpClient) { }
  registerMode = false;
  values: any;
  ngOnInit() {
    this.getValues();
  }
  registerToggel() {
    this.registerMode = !this.registerMode;
  }
  getValues() {

    this.http.get('https://localhost:44331/api/values').subscribe(res => {
this.values = res;
console.log(res , 'valuesssssss ');

} , error => {
  console.log(error);
});
      }

      cancelRegisterEvent(registerMode: boolean) {
         this.registerMode = registerMode;
      }
}

