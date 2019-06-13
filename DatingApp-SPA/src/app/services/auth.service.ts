import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';
import { CommonConfig } from '../config/CommonConfig';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  config: CommonConfig;
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  constructor(private http: HttpClient) {
    this.config = new CommonConfig();
  }

  login(model: User) {
    return this.http
      .post(this.config.baseUrl + this.config.loginUrl, model)
      .pipe(
        map((resp: any) => {
          const user = resp;
          if (user) {
            localStorage.setItem('token', user.token);
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
          }
        })
      );
  }

  register(model: User) {
    return this.http.post(this.config.baseUrl + this.config.registerUrl, model);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
