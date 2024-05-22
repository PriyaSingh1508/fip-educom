import { Injectable } from '@angular/core';
import { CommonHttpService } from '../shared/services/common-http.service';
import { BehaviorSubject, Observable } from 'rxjs';




@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  constructor(private articleHttp:CommonHttpService) { }

  getData<T>(endpoint: string): Observable<T> {
    return this.articleHttp.get<T>(endpoint);
  }


  private dataSubject = new BehaviorSubject<any>("Hi");
  data$ = this.dataSubject.asObservable();

  setData(data: any) {
    this.dataSubject.next(data);
  }
}
