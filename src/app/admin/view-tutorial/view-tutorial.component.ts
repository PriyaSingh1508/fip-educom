import { Component, ViewChild } from '@angular/core';
import { AdminService } from '../admin.service';
import { GetAllTutorials, RequestModel, ResponseModel} from 'src/app/model';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { ViewDialogComponent } from '../view-dialog/view-dialog.component';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { Dictionary } from 'src/app/shared/common/dictionary';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-view-tutorial',
  templateUrl: './view-tutorial.component.html',
  styleUrls: ['./view-tutorial.component.css']
})
export class ViewTutorialComponent {
  constructor(private service:AdminService,public dialog: MatDialog, private router:Router){

  }
  pageChanged(event: any) {
    this.currentPage = event.pageIndex +1; 
    this.pageSize = event.pageSize;
    this.getTutorialList();
  }
  totalItems = 5;
  pageSize = 2;
  currentPage = 1;
  @ViewChild(MatPaginator) paginator !:MatPaginator;
  displayedColumns: string[] = [
  "tutorialCategoryId",
  "topic",
  // "description",
      "actions"];
tutorialList:GetAllTutorials[]=[];
dataSource:any;
ngOnInit():void{
  this.getTutorialList();
}
getTutorialList(){
  const requestData:RequestModel={
    id:null,
    itemsPerPage:this.pageSize,
    pageNo:this.currentPage
    }
   
    
      // Technology/get-all-categories?Page=${this.currentPage}&ItemsPerPage=${this.pageSize}
      let header=new Dictionary();
      header.add('id',requestData.id);
      header.add('itemsPerPage',requestData.itemsPerPage);
      header.add('pageNo',requestData.pageNo);
      console.log(header['itemsPerPage']);
      // let headers=new HttpHeaders();
      // headers= header.createHttpHeadersFromDictionary(header);
      let headers=header.AddHeader('id',requestData.id);
         console.log(headers);
        headers=header.AddHeader('itemsPerPage',requestData.itemsPerPage,headers);
        headers=header.AddHeader('pageNo',requestData.pageNo,headers);
this.service.getData<ResponseModel<GetAllTutorials[]>>('Technology/getalltutorials',headers).subscribe((data)=>{
  this.tutorialList = data.data;
        this.totalItems=data.totalRecords;
        this.dataSource=this.tutorialList;
        this.dataSource.paginator=this.paginator;
})
}

openDialog(event:any) {
  const dialogRef = this.dialog.open(ViewDialogComponent,{
    data: {topic:event?.topic, description: event?.description }
  });

  dialogRef.afterClosed().subscribe(result => {
    console.log(`Dialog result: ${result}`);
  });
}
applyFilter(event: Event) {
  const filterValue = (event.target as HTMLInputElement).value;
  this.dataSource.filter = filterValue.trim().toLowerCase();
}
OnPublish(element:GetAllTutorials){
  console.log(element);
  let data: GetAllTutorials={
    id:element.id,
        technologyId: element.technologyId,
        tutorialCategoryId:element.tutorialCategoryId,
        topic: element.topic,
        description:element.description,
        isPublished:true  };
  

  this.service.putData<{message:string}>(`Technology/update-tutorial`,data).subscribe({
    next:(res)=>{
      console.log ("res",res);
      

      this.getTutorialList();
      
      
    
    },error:(err)=>{
      console.log("error",err);
      
      

    }
  })
  

}
OnDelete(element:GetAllTutorials){
  console.log(element);
  this.service.deleteData<{message:string}>(`Technology/delete-tutorial/${element.id}`).subscribe({
    next:(res)=>{
      console.log ("res",res);                      

      this.getTutorialList();
      
      
    
    },error:(err)=>{
      console.log("error",err);
      
      

    }
  })
}

OnEdit(element:GetAllTutorials){
 this.router.navigateByUrl(`edit-tutorial/${element.id}`);
}
}
