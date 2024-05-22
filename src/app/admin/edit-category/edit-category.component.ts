import { Component } from '@angular/core';
import { ResponseModel, TechnologyDTO, TutorialCategoryDTO } from 'src/app/model';
import { AdminService } from '../admin.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent {
  public  technologies:TechnologyDTO[]=[];
  public editCategoryForm!:FormGroup;
  public categoryInfo!:Category;
  constructor(private adminService:AdminService,private fb: FormBuilder,private route: ActivatedRoute,private router :Router,private _snackBar: MatSnackBar) {
    this.editCategoryForm = fb.group({
      TechnologyId: [0, [Validators.required]],
      TutorialCategoryName: ['', [ Validators.required]]
    });

    this.editCategoryForm.get('TechnologyId')?.valueChanges.subscribe(() => {
      this.resetTutorialCategoryName();
    });
  }
  
  ngOnInit(): void {
    this.getTechnologies();  
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.loadCategoryData( params['id']);
      }
    });
  } 

  loadCategoryData(id:number){
   this.adminService.getData<ResponseModel<Category>>(`Technology/get-category-by-id/${id}`).subscribe(
    (data) => {
    
       this.categoryInfo=data.data;  
      this.editCategoryForm.setValue({
        TechnologyId: data.data.technologyId,
        TutorialCategoryName:data.data.tutorialCategoryName
      })
    },
    (error) => {
      console.log('Something went wrong: ', error);
    }
  );
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
 
  resetTutorialCategoryName(){
    this.editCategoryForm.controls['TutorialCategoryName'].reset();
  }

  onSubmit(){
   
    this.categoryInfo.isPublished=false;
    this.categoryInfo.technologyId=this.editCategoryForm.get('TechnologyId')?.value;
    this.categoryInfo.tutorialCategoryName=this.editCategoryForm.get('TutorialCategoryName')?.value;
    console.log(this.categoryInfo);
    this.adminService.putData<{message:string}>(`Technology/update-tutorial-category`,this.categoryInfo).subscribe({
      next:(res)=>{
        console.log ("res",res);
        this.editCategoryForm.reset();
        this._snackBar.open("Edited Successfully", "close",{
          duration: 4000
        });
        
      
      },error:(err)=>{
        console.log("error",err);
        

      }
    })
  }
}

export interface Category{
  "id":number,
  "technologyId":number,
"  technologyName":string,
 "tutorialCategoryName":string,
  "isPublished":boolean
}
