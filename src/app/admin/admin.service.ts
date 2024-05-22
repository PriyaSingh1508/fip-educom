import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CommonHttpService } from '../shared/services/common-http.service';
import { HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class AdminService {

    constructor(private commonHttp:CommonHttpService) { }
    
   

    getData<T>(endpoint: string,headers?:HttpHeaders): Observable<T> {
      return this.commonHttp.get<T>(endpoint,headers);
    }

    postData<T>(endpoint: string, data: any,headers?:HttpHeaders): Observable<T>{
      return this.commonHttp.post<T>(endpoint,data,headers);
    }
    putData<T>(endpoint:string,data:any):Observable<T>{
      return this.commonHttp.put<T>(endpoint,data);
    }
    deleteData<T>(endpoint:string):Observable<T>{
      return this.commonHttp.delete<T>(endpoint);
    }
    
}
