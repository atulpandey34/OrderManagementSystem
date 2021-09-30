import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Result } from '../model/result';
import { BaseService } from './base-service';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationService extends BaseService {
  
  private urls = {
    login: 'members/authentication',
    
  };

  constructor(httpClient: HttpClient, private router: Router) {
    super(httpClient);
  }

  get isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  
  login(email: string, password: string): Observable<any> {
    return this.httpPost(this.urls.login, {
      userName: email,
      password: password
    }).pipe(
      map(response => {
        const res: Result = response as Result;
        if (res && res !== null && res.header.success === true) {
          console.log('res', res);
          //this.authenticatedUser = res.data as AuthenticatedUserModel;
          //console.log('this.authenticatedUser', this.authenticatedUser);
          localStorage.setItem('token', res.data.token);
          
        }
        return res.data;
      }, (error) => {
        throwError(error);
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.clear();
    return true;
  }

}
