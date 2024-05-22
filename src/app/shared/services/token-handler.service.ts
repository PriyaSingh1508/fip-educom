import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class TokenHandlerService {

  constructor() { }
  setToken(data: any): void {
    sessionStorage.setItem('token', JSON.stringify(data));
  }
  getToken():any{
    const data = sessionStorage.getItem('token');
    if(data){
      console.log(data);
      return JSON.parse(data);
    }
  }
  decodedToken(){
    const jwtservice= new JwtHelperService();
    const token=this.getToken()!;
    return jwtservice.decodeToken(token);
  }

}
