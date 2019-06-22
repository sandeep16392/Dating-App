import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import { environment } from 'src/environments/environment';
import { PaginationResult } from '../models/pagination';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) {}

  getUsers(page?, itemsPerPage?, userParams?): Observable<PaginationResult<User[]>> {
    const paginatedResult: PaginationResult<User[]> = new PaginationResult<
      User[]
    >();

    let params = new HttpParams();
    if (page && itemsPerPage) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    if (userParams != null) {
      params = params.append('minAge', userParams.minAge);
      params = params.append('maxAge', userParams.maxAge);
      params = params.append('gender', userParams.gender);
      params = params.append('orderBy', userParams.orderBy);
    }

    return this.http
      .get<any>(environment.baseUrl + 'api/users', {
        observe: 'response',
        params
      })
      .pipe(
        map(response => {
          paginatedResult.result = response.body.users;
          paginatedResult.pagination = response.body.pagination;
          // if (response.headers.get('Pagination')) {
          //   paginatedResult.pagination = JSON.parse(
          //     response.headers.get('Pagination')
          //   );
          // }
          return paginatedResult;
        })
      );
  }

  getUser(id: number): Observable<User> {
    return this.http.get<User>(environment.baseUrl + 'api/users/' + id);
  }

  updateUser(id: number, user: User) {
    return this.http.put(environment.baseUrl + 'api/users/' + id, user);
  }

  setMainPhoto(userid: number, id: number) {
    return this.http.post(
      environment.baseUrl +
        'api/users/' +
        userid +
        '/photos/' +
        id +
        '/setmain',
      {}
    );
  }

  deletePhoto(userid: number, id: number) {
    return this.http.delete(
      environment.baseUrl + 'api/Users/' + userid + '/photos/' + id
    );
  }
}
