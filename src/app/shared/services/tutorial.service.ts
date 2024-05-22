import { Injectable } from '@angular/core';
import { CommonHttpService } from './common-http.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TutorialService {

  constructor(private commonHttp:CommonHttpService) {

   }
   getData<T>(endpoint: string): Observable<T> {
    return this.commonHttp.get<T>(endpoint);
  }

  getJsonData<T>(endpoint: string): Observable<T> {
    return this.commonHttp.getJson<T>(endpoint);
  }
}
