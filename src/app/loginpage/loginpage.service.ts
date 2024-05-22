import { Injectable } from '@angular/core';
import { CommonHttpService } from '../shared/services/common-http.service';
import { Observable } from 'rxjs';
import { TokenHandlerService } from '../shared/services/token-handler.service';

@Injectable({
  providedIn: 'root'
})
export class LoginpageService {

  constructor(private commonHttp:CommonHttpService,private tokenService:TokenHandlerService) { }

  postData<T>(endpoint: string,data:any): Observable<T> {
    return this.commonHttp.post<T>(endpoint,data);
  }
  setToken(data: any): void {
    return this.tokenService.setToken(data);
  }
  getToken(){
    return this.tokenService.getToken();
  }
}
