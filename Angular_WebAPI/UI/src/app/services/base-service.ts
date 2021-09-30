import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Result } from '../model/result';
import { environment } from '../../environments/environment';


@Injectable({
	providedIn: 'root'
})
export class BaseService {

	constructor(public httpClient: HttpClient) { }

  protected httpPost(url: string, param?: any): Observable<Result> {
    return this.httpClient.post(environment.apiBaseUrl + url, param)
      .pipe(map(res => res as Result)
				, catchError(error => this.handleError(error)));
	}

	protected httpGet(url: string): Observable<Result> {
    return this.httpClient.get(environment.apiBaseUrl + url)
			.pipe(map(res => res as Result)
				, catchError(error => this.handleError(error)));
	}

	public handleError(error: any) {
    return throwError(error);
	}
}
