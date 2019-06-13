import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { User } from '../models/User';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user = new User();
  @Output() cancelRegister= new EventEmitter();
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.user).subscribe(() => {
      console.log('Registered!');
    },
    error => {
      console.log('Error!');
    });
  }

  cancel() {
    this.user.password = '';
    this.user.username = '';
    this.cancelRegister.emit(false);
  }
}
