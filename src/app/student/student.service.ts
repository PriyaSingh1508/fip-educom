import { Injectable } from '@angular/core';
import { CommonHttpService } from '../shared/services/common-http.service';
import { Observable } from 'rxjs';
import { StudentDetail } from '../model';


@Injectable({
  providedIn: 'root'
})
export class StudentService {
  students:any;

  constructor(private commonHttp:CommonHttpService) { }
  getData<T>(endpoint: string): Observable<T> {
    return this.commonHttp.get<T>(endpoint);

  }
  postData<T>(endpoint: string,data:any): Observable<T> {
    return this.commonHttp.post<T>(endpoint,data);

  }
  saveStudent(student: StudentDetail) {
    this.students = localStorage.getItem('students');
    if (this.students) {
      this.students = JSON.parse(this.students);
      this.students.push(student);
    } else {
      this.students = [student];
    }
    localStorage.setItem('students', JSON.stringify(this.students));
  }
  getDataLocal(): StudentDetail[] {
    const data = localStorage.getItem('my-data');
    if (data) {
      return JSON.parse(data);
    } else {
      return [];
    }
  }
 
  setData(data: StudentDetail[]): void {
    localStorage.setItem('my-data', JSON.stringify(data));
  }
}



