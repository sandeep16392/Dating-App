import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) {}

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(environment.baseUrl + 'api/users');
  }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(environment.baseUrl + 'api/users/' + id);
  }

  updateUser(id: number, user: User) {
    return this.http.put(environment.baseUrl + 'api/users/' + id, user);
  }
}
