import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonConfig } from '../config/CommonConfig';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from '../../environments/environment';

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

  login(model: any) {
    return this.http
      .post(environment.baseUrl + environment.loginUrl, model)
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

  register(model: any) {
    return this.http.post(environment.baseUrl + environment.registerUrl, model);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }
}
