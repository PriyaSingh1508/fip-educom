import { Component, OnInit } from '@angular/core';
import { ResponseModel, StudentDetail } from 'src/app/model';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  users:StudentDetail[]=[];
  dataSource:any;
 
  constructor(private service : StudentService) {
  

  }
  ngOnInit(): void {
    this.GetAllUsers();
  }
  displayedColumns:string[]=["id","name","email","mobilenumber","actions"] ;
  GetAllUsers(){
    this.service.getData<ResponseModel<StudentDetail[]>>('Student/GetAllStudents').subscribe((data)=>{
     this.users=data.data;
    //  this.service.setData(this.users);
     console.log(this.users);
     
   
     this.dataSource= this.users;
 
 
 
 
     },(error)=>{
       console.log(error);
     })
   }
 DeleteUser(id:any){
//    let user:StudentDetail[]=this.service.getDataLocal();
//    console.log(user);
 
//   const index=user.findIndex(item=>item.id==id);
//   if(index!=-1){
//    if (index !== -1) {
//      user.splice(index, 1);
//      console.log(`Item with ID ${id} deleted successfully.`);
//      this.service.setData(user);
//  } else {
//      console.log(`Item with ID ${id} not found.`);
//  }
//  this.dataSource=this.service.getDataLocal();
//   }
 
 }



}
