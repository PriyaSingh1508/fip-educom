import { Injectable } from '@angular/core';
import { CommonHttpService } from '../shared/services/common-http.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TeacherService {
  constructor(private teacherHttp:CommonHttpService) { }
  getData<T>(endpoint: string): Observable<T> {
    return this.teacherHttp.get<T>(endpoint);
  }
}
