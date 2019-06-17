import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model = {username: '', password: ''};
  constructor(public authService: AuthService, private alertify: AlertifyService,
    private route: Router) {}

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        this.alertify.success('Logged In!');
      },
      error => {
        this.alertify.error(error);
      }, () => {
        this.route.navigate(['/members']);
      }    );
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('Logged Out!');
    this.route.navigate(['/home']);
  }
}
