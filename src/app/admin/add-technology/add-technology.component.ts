import { Component, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { RequestModel, ResponseModel, TechnologyDTO} from 'src/app/model';
import { AdminService } from '../admin.service';
import { Observable } from 'rxjs';
import { Dictionary } from 'src/app/shared/common/dictionary';
import { MatPaginator } from '@angular/material/paginator';
import { HttpHeaders } from '@angular/common/http';




@Component({
  selector: 'app-add-technology',
  templateUrl: './add-technology.component.html',
  styleUrls: ['./add-technology.component.css']
})
export class AddTechnologyComponent implements OnInit{
  totalItems = 5;
  pageSize = 2;
  currentPage = 1;
  techForm!: FormGroup;
  techs:TechnologyDTO[]=[];
  selectedFile!:File;
  dataSource:any
  displayedColumns:string[]=["id","technologyName","imageUrl","actions"];
  @ViewChild(MatPaginator) paginator !:MatPaginator;
  constructor(private fb: FormBuilder,private service:AdminService) {
   
    this.createForm();
  }
  pageChanged(event: any) {
    this.currentPage = event.pageIndex +1; 
    this.pageSize = event.pageSize;
    this.getTechnologies();
  }

  // technology:TechnologyDTO={
  //   id:0,
  //   technologyName:"",
  //   imageUrl:""
  // }
  ngOnInit(): void {
   this.getTechnologies();
  }
  createForm() {
    this.techForm = this.fb.group({
      technologyName: ['', Validators.required],
      fileInput: [null, Validators.required]
    });
  }
  onSubmit() {
    if (this.techForm.valid) {
      console.log(this.techForm.value);
      // console.log(this.technology);
      const formData=new FormData();
      formData.append("name",this.TechnologyName.value);
      formData.append("image",this.selectedFile);
      console.log(formData);
      // const head={"ContentType":"multipart/form-data"};
      let dict = new Dictionary();
      dict.add("ContentType","multipart/form-data");
      let headers=dict.createHttpHeadersFromDictionary(dict);
      
      this.service.postData<{message:string}>('Technology/add-technology',formData,headers).subscribe({
        next:(res)=>{
          console.log ("res",res);
          this.techForm.reset();
          // this.technology={
          //   id:0,
          //   technologyName:"",
          //   imageUrl:""
          // }

          this.getTechnologies();
          
          
        
        },error:(err)=>{
          console.log("error",err);
          
          
  
        }
      })
    } 


    
  }
  onPublish(element:TechnologyDTO){
    console.log(element);
    element.isPublished=true;
    this.service.putData<{message:string}>(`Technology/update-technology`,element).subscribe({
      next:(res)=>{
        console.log ("res",res);
        

        this.getTechnologies();
        
        
        
      
      },error:(err)=>{
        console.log("error",err);
        
        

      }
    })
    

  }
    getTechnologies(){
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
      this.service.getData<ResponseModel<TechnologyDTO[]>>("Technology/get-all-technologies",headers).subscribe((data)=>{
        this.techs = data.data;
        this.totalItems=data.totalRecords;
        this.dataSource=this.techs;
        this.dataSource.paginator=this.paginator;
        // this.dataSource = new MatTableDataSource(this.techs);
       
       
    
      },(error)=>{
        console.error("error",error);
      })
     }
     onFileSelected(event:any){
      if(event.target.files.length>0){

        const file=event.target.files[0];
        this.selectedFile=file;
      }

     }
     get TechnologyName():FormControl{

      return this.techForm.get('technologyName') as FormControl;
    }
    // get ImageUrl():FormControl{
  
    //   return this.techForm.get('imageUrl') as FormControl;
    // }
    
    
    get FileInput():FormControl{
    
      return this.techForm.get('fileInput') as FormControl;
    
    }
    onDelete(element:TechnologyDTO){
      this.service.deleteData<{message:string}>(`Technology/delete-technology/${element.id}`).subscribe({
        next:(res)=>{
          console.log ("res",res);
          
  
          this.getTechnologies();
          
          
        
        },error:(err)=>{
          console.log("error",err);
          
          
  
        }
      })
    }
 
}
