import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators, } from '@angular/forms';
import { RequestModel,ResponseModel, TechnologyDTO, TechnologyTutorialCategory, TutorialCategoriesDTO } from 'src/app/model';
import { AdminService } from '../admin.service';
import {  HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { Dictionary } from 'src/app/shared/common/dictionary';


interface IRegister {
  succeeded: boolean,
  errors: any[]
};
@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {
  dataSource:any
  displayedColumns:string[]=["id","technologyName","tutorialCategoryName","actions"];
  public  technologies:TechnologyDTO[]=[];
  public allCategories:TutorialCategoriesDTO[]=[];
  addCategoryForm!: FormGroup;
  showFormError: boolean = false;
  showError:boolean=false;
  totalItems = 4;
  pageSize = 3;
  currentPage = 1;
  @ViewChild(MatPaginator) paginator !:MatPaginator;


 headers = new HttpHeaders().set('Content-Type', 'application/json');
  constructor(private fb: FormBuilder, private adminService:AdminService,private router:Router) {
    this.addCategoryForm = fb.group({
      TechnologyId: [0, [Validators.required]],
      TutorialCategoryName: fb.array([this.createCategoryGroup()], [ Validators.required])
    });

    this.addCategoryForm.get('TechnologyId')?.valueChanges.subscribe(() => {
      this.resetTutorialCategoryName();
    });
  }
  ngOnInit(): void {
    this.getTechnologies();
    this.getAllCategories();
  
  } 
  pageChanged(event: any) {
    this.currentPage = event.pageIndex +1; 
    this.pageSize = event.pageSize;
    this.getAllCategories();
  }

  private getTechnologies() {
    this.adminService.getData<ResponseModel<TechnologyDTO[]>>("Technology/get-technologies").subscribe(
      (data) => {
        this.technologies = data.data;
        console.log("Tech ",this.technologies)
      },
      (error) => {
        console.log('Something went wrong: ', error);
      }
    );
  }
  private getAllCategories() {
    const requestData:RequestModel={
      id:null,
      itemsPerPage:this.pageSize,
      pageNo:this.currentPage
      }
      let param={
        'id':requestData.id,
        'itemsPerPage':requestData.itemsPerPage,
        'pageNo':requestData.pageNo
      }
      
        // Technology/get-all-categories?Page=${this.currentPage}&ItemsPerPage=${this.pageSize}
        let header=new Dictionary();
        header.add('id',requestData.id);
        header.add('itemsPerPage',requestData.itemsPerPage);
        header.add('pageNo',requestData.pageNo);
        console.log(header['itemsPerPage']);
          // let headers=new HttpHeaders();
         let headers=header.AddHeader('id',requestData.id);
         console.log(headers);
        headers=header.AddHeader('itemsPerPage',requestData.itemsPerPage,headers);
        headers=header.AddHeader('pageNo',requestData.pageNo,headers);
        console.log(headers);
        // headers= header.createHttpHeadersFromDictionary(header);
        
       
    this.adminService.getData<ResponseModel<TutorialCategoriesDTO[]>>(`Technology/get-all-categories`,headers).subscribe(
      (data) => {
        this.allCategories = data.data;
        this.totalItems=data.totalRecords;
        this.dataSource=this.allCategories;
        this.dataSource.paginator=this.paginator;
        console.log("Hi ",this.allCategories);
      },
      (error) => {
        console.log('Something went wrong: ', error);
      }
    );
  }
  createCategoryGroup(): FormGroup {
    return this.fb.group({
      name: ['']
    });
  }

  resetTutorialCategoryName() {
    const tutorialCategoryArray = this.addCategoryForm.get('TutorialCategoryName') as FormArray;
    tutorialCategoryArray.clear();
    tutorialCategoryArray.push(this.createCategoryGroup());
  }

  get TutorialCategoryName() {
    return this.addCategoryForm.get('TutorialCategoryName') as FormArray;
  }

  addCategory() {   this.TutorialCategoryName.insert(0, this.createCategoryGroup()) }

  removeCategory(index: number) {
    this.TutorialCategoryName.removeAt(index);
  }

  
  onSubmit() {
    if(this.addCategoryForm.get('TechnologyId')?.value!=0) {
      // Check for empty values in the form array
      
      const formArray = this.addCategoryForm.get('TutorialCategoryName') as FormArray;
      const hasEmptyValue = formArray.controls.some(control => control.get('name')?.value.trim() === '');
      const error=formArray.length<=0
      if(!hasEmptyValue && !error){
       // console.log(this.addCategoryForm.value);
      const categoryObj = {
        TechnologyId: this.addCategoryForm.get('TechnologyId')?.value,
        TutorialCategoryName: this.addCategoryForm.get('TutorialCategoryName')?.value.map((category: { name: string }) => category.name)
      };
     
      console.log(categoryObj);
  
      this.adminService.postData<{ message: string }>('Technology/add-tutorial-category', categoryObj).subscribe({
        next: (res) => {
          console.log('res', res);
          this.addCategoryForm.reset();
         
          this.getAllCategories();
          this.showError=false;
          this.showFormError=false;
          console.log("d",this.getAllCategories);
        },
        error: (err) => {
          console.log('error', err);
        }
      });
      }
      else{
   this.showError=true;
   console.log("At least one category name must be there")
      }
   
    }else{
      this.showFormError=true;
      console.log('Invalid');
      
    }
     
  }
  onPublish(element:TutorialCategoriesDTO){
    console.log(element);
    element.isPublished=true;
    console.log(element);
    this.adminService.putData<{message:string}>(`Technology/update-tutorial-category`,element).subscribe({
      next:(res)=>{
        console.log ("res",res);
        console.log(element);
      
        

        this.getAllCategories();
        
        
      
      },error:(err)=>{
        console.log("error",err);
        
        

      }
    })
    

  }
  onDelete(element:TutorialCategoriesDTO){
    this.adminService.deleteData<{message:string}>(`Technology/delete-tutorial-category/${element.id}`).subscribe({
      next:(res)=>{
        console.log ("res",res);
        

        this.getAllCategories();
        
        
      
      },error:(err)=>{
        console.log("error",err);
        
        

      }
    })
  }

  onEdit(element:number){
    this.router.navigateByUrl(`edit-category/${element}`)
  }
}
