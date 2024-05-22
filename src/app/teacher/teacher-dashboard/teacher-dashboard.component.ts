import { Component } from '@angular/core';

import { TeacherService } from '../teacher.service';
import { User } from 'src/app/model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-teacher-dashboard',
  templateUrl: './teacher-dashboard.component.html',
  styleUrls: ['./teacher-dashboard.component.css']
})
export class TeacherDashboardComponent {
 
  constructor( private teacherService: TeacherService,private router: Router){}

  
  ngOnInit(): void {
    this.getDataAndStoreLocally();
  }

  getDataAndStoreLocally(): void {
    this.teacherService.getData<User[]>('teacherlist.json').subscribe(
      (data: any) => {
        // Convert the JSON data to a string
        const jsonDataString = JSON.stringify(data);
        // Store the stringified JSON data in local storage
        localStorage.setItem('teacherList', jsonDataString);
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

   list = localStorage.getItem('teacherList') ? JSON.parse(localStorage.getItem('teacherList')!) : console.error('No data found in local storage');
   editRecord(id: number){
    this.router.navigate(['/teacher-dashboard/edit-record',id])
  }
  viewRecord(id:number){
    this.router.navigate(['/teacher-dashboard/view-record',id])
  }
  deleteRecord(id:number){
    for(let i = 0; i <this.list.length; i++) {
      if(this.list[i].id== id) {
          this.list.splice(i, 1);
      }
   }
      // Set New Todos
      localStorage.setItem('teacherList', JSON.stringify(this.list));
  }
}
