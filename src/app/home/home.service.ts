import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommonHttpService } from '../shared/services/common-http.service';
// Define interfaces
@Injectable({
  providedIn: 'root'
})
export class HomeService {

    constructor(private commonHttp:CommonHttpService) { }
    
   

    getData<T>(endpoint: string,headers?:any): Observable<T> {
      return this.commonHttp.get<T>(endpoint);
    }
    
}