import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service'
import { Result } from '../model/result';

@Injectable()
export class AuthhttpInterceptor implements HttpInterceptor {
	constructor(private router: Router,
		private authservice: AuthenticationService,
	) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = localStorage.token;

    if (!token) {
      return next.handle(req);
    }

    const req1 = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${token}`),
    });

    return next.handle(req1)
      .pipe(
        map(res => {
          if (res && res['status'] && res['status'] !== 200) {
            //this.authservice.logout();
            this.router.navigate(['/login']);
          }
          return res;
        }),
        catchError(err => {
          const result: Result = err.error as Result;
          if (err && !err.error && err.status === 401) {
            //this.authservice.logout();
            this.router.navigate(['/login']);
          }

          return throwError(err);
        })
      );
  }
}
