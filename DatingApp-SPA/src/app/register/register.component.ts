import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() valuesFormHome: any;
  @Output() cancelRegister = new EventEmitter;
  constructor(private auth: AuthService) { }
  model: any = {};
  ngOnInit() {
  }
  register() {
    // console.log(this.model, 'asdfghjk');
    this.auth.register(this.model);
  }
  cancel() {
    console.log('this.modelthis.modelthis.model', this.model);
    this.model = {};
    this.cancelRegister.emit(false);
  }
  // try() {
  //   console.log(this.valuesFormHome, 'valuesFormHome');
  // }
}
