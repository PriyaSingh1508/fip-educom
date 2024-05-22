import { Component, OnInit } from '@angular/core';
import { StudentDetail } from 'src/app/model';
import { StudentService } from '../student.service';
import { MatTableDataSource } from '@angular/material/table';


@Component({
  selector: 'app-student-dashboard',
  templateUrl: './student-dashboard.component.html',
  styleUrls: ['./student-dashboard.component.css']
})
export class StudentDashboardComponent implements OnInit {
  // users:StudentDetail[]=[];
  selectedTab:string='dashboard';
  // dataSource:any;
  // displayedColumns:string[]=["id","name","email","mobilenumber","actions"]
  constructor(private service:StudentService) {

    
    
  }
  ngOnInit(): void {
    // this.GetAllUsers();
    
  }
  selectTab(tab:string){
    this.selectedTab=tab;
  }
//    GetAllUsers(){
//    this.service.getData<StudentDetail[]>('user.json').subscribe((data)=>{
//     this.users=data;
//     this.service.setData(this.users);
//     console.log(this.users);
    
  
//     this.dataSource= this.users;




//     },(error)=>{
//       console.log(error);
//     })
//   }
// DeleteUser(id:any){
//   let user:StudentDetail[]=this.service.getDataLocal();
//   console.log(user);

//  const index=user.findIndex(item=>item.id==id);
//  if(index!=-1){
//   if (index !== -1) {
//     user.splice(index, 1);
//     console.log(`Item with ID ${id} deleted successfully.`);
//     this.service.setData(user);
// } else {
//     console.log(`Item with ID ${id} not found.`);
// }
// this.dataSource=this.service.getDataLocal();
//  }

// }

}
