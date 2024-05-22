import { Injectable } from '@angular/core';
import { CommonHttpService } from '../shared/services/common-http.service';
import { Observable } from 'rxjs';

@Injectable()
export class LibraryService {

  constructor(private commonHttp:CommonHttpService) { }
  getData<T>(endpoint: string): Observable<T> {
    return this.commonHttp.get<T>(endpoint);
  }


}
