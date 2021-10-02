import { Injectable } from '@angular/core';
import { BaseService } from './base-service';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError, BehaviorSubject, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Result } from '../model/result';

@Injectable({
  providedIn: 'root'
})
export class OrderService extends BaseService {

  private urls = {
    getall: 'orders/getall',

  };

  constructor(httpClient: HttpClient) {
    super(httpClient);
  }

  GetOrdersList(userID: number): Observable<any> {
    return this.httpGet(this.urls.getall +`?userId=${userID}`).pipe(
      map(response => {
        const res: Result = response as Result;
        if (res && res !== null && res.header.success === true) {
          console.log('res', res);
         
        }
        return res.data;
      }, (error) => {
        throwError(error);
      })
    );
  }

}
