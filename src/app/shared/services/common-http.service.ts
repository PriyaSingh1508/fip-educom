// shared/http.service.ts
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenHandlerService } from './token-handler.service';

import { baseUrl } from 'src/assets/configs/config';
import { JsonPipe } from '@angular/common';
@Injectable({
  providedIn: 'root',
})
export class CommonHttpService {

  // private baseUrl2='../../assets/data';
 
 private baseUrl='https://localhost:7181/api'
  constructor(private http: HttpClient, private tokenHandler:TokenHandlerService) {
   
  }
  private getOptions(options:HttpHeaders){
let header=new HttpHeaders();
if(options){
  header=options;
}
return header;
  }
  // private getHeaders(options?:string): HttpHeaders {
  //   const authToken = this.tokenHandler.getToken();
  //   return new HttpHeaders({
  //     'Content-Type': options=="file"?'multipart/form-data' :'application/json',
  //     Authorization: `Bearer ${authToken?.jwtToken}`,
  //   });
  // }

 


  get<T>(endpoint: string,options?:HttpHeaders): Observable<T> {
    // let headers=new HttpHeaders();
    // if(options){
    //   headers= this.getHeader(options);}
    // const params = this.setParams(options);
    let headers=new HttpHeaders();
    if(options){
    headers=this.getOptions(options);}

    console.log(headers);

    return this.http.get<T>(`${baseUrl}/${endpoint}`,{headers});
  }

  post<T>(endpoint: string, data: any,options?:HttpHeaders) :Observable<T> {
    let headers=new HttpHeaders();
    if(options){
    headers=this.getOptions(options);}

    return this.http.post<T>(`${baseUrl}/${endpoint}`, data, {headers});
  }

  put<T>(endpoint: string, data: any,options?:HttpHeaders): Observable<T> {
    let headers=new HttpHeaders();
    if(options){
    headers=this.getOptions(options);}
    return this.http.put<T>(`${baseUrl}/${endpoint}`, data,{headers});
  }

  delete<T>(endpoint: string): Observable<T> {
    
    return this.http.delete<T>(`${baseUrl}/${endpoint}`);
  }
  getJson<T>(endpoint: string,options?:string): Observable<T> {
    // const headers= this.getHeaders(options);
    return this.http.get<T>(`${endpoint}`);//,{headers}
  }




}

