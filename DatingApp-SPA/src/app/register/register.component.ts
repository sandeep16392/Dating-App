import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { User } from '../models/User';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user = new User();
  @Input() valuesFromHome: any;
  @Output() cancelRegister= new EventEmitter();
  constructor() { }

  ngOnInit() {
  }

  register() {

  }

  cancel() {
    this.user.password = '';
    this.user.username = '';
    this.cancelRegister.emit(false);
  }
}
