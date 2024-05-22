import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { CommonHttpService } from '../services/common-http.service';
import { Router } from '@angular/router';
import { TokenHandlerService } from '../services/token-handler.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private service: TokenHandlerService,private router:Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const myToken = this.service.getToken();
    
    if(!!myToken){
      request=request.clone({
        setHeaders:{Authorization:`Bearer ${myToken.jwtToken}`}
      });
    }

    return next.handle(request).pipe(catchError((err:any)=>{
      console.error(err);
      if(err instanceof HttpErrorResponse){
          if(err.status===401){
            this.router.navigateByUrl('login');
          }
          
      }
      return throwError(()=>new Error(JSON.stringify(err)));



    }));
  }
}
