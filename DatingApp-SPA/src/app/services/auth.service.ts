import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/User';
import { CommonConfig } from '../config/CommonConfig';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  config: CommonConfig;
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
          }
        })
      );
  }

  register(model: User) {
    return this.http.post(this.config.baseUrl + this.config.registerUrl, model);
  }
}
