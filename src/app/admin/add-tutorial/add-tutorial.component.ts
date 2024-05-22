import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import Editor from 'ckeditor5-custom-build/build/ckeditor';
import { GetAllTutorials, ResponseModel, TechnologyDTO, TutorialCategoryDTO, TutorialRegister } from 'src/app/model';
import { AdminService } from '../admin.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-add-tutorial',
  templateUrl: './add-tutorial.component.html',
  styleUrls: ['./add-tutorial.component.css']
})

export class AddTutorialComponent implements OnInit{
  // public Editor = ClassicEditor;
  public Editor = Editor;
  public editorData: string = '';
  formData!: FormGroup;
  technologies:TechnologyDTO[]=[];
  categories:TutorialCategoryDTO[]=[];
  response:any;
  techId=0;
  tutorial:TutorialRegister={
    technologyId:0,
    tutorialCategoryId: 0,
    topic:"",
    description:""
  }
  tutorialId!:number;
  //for editing
  isEditMode: boolean = false;
   categoryId!: number;

  constructor(private formBuilder: FormBuilder, private service:AdminService,private _snackBar: MatSnackBar,private route: ActivatedRoute,private router:Router) { 
  
  }

  ngOnInit(): void {
    this.formData = this.formBuilder.group({
      TechnologyId:0,
      TutorialCategoryId: [0, Validators.required],
      Topic: ['', Validators.required],
      Description: ['', Validators.required]

    });
    this.getTechnologies();
    this.route.params.subscribe(params => {
      if (params['id']) {
        this.isEditMode = true;
        this.loadTutorialData( params['id']);
      }
    });
    
  }
    //for edit
    loadTutorialData(tutorialId: number): void {
      this.service.getData<ResponseModel<GetAllTutorials>>(`Technology/get-tutorial/${tutorialId}`).subscribe((data)=>{
        console.log(data);
      this.getCategories(data.data.technologyId);
      this.tutorialId=data.data.id;
      this.formData.setValue({
        TechnologyId: data.data.technologyId,
        TutorialCategoryId: data.data.tutorialCategoryId,
        Topic: data.data.topic,
        Description: data.data.description
      });
      },(error)=>{
        console.log("error",error);
      });
     
    }
    

  getTechnologies(){
    this.service.getData<ResponseModel<TechnologyDTO[]>>("Technology/get-technologies").subscribe((data)=>{
      this.technologies=data.data;
     
  
    },(error)=>{
      console.error("error",error);
    })
   }
   getCategories(event:any){
    console.log(event);
    // let data= event?event:this.tutorial.technologyId;
    

    this.service.getData<ResponseModel<TutorialCategoryDTO[]>>(`Technology/get-tutorial-categories/${event}`).subscribe((data)=>{
      this.categories=data.data;
     
  
    },(error)=>{
      console.log("error");
    })
   }
  

  onSubmit() { 
    if (this.formData!.valid) {
      console.log(this.formData!.value);
      console.log(this.tutorial);

  
      if(!this.isEditMode){
        this.service.postData<{message:string}>('Technology/add-tutorial',this.tutorial).subscribe({
          next:(res)=>{
            console.log ("res",res);
            this.tutorial={
              technologyId:0,
              tutorialCategoryId: 0,
              topic:"",
              description:""
            }
            this.formData.reset();
            this._snackBar.open(res?.message, "close",{
              duration: 4000
            });
            
          
          },error:(err)=>{
            console.log("error",err);
            
    
          }
        })
      }
   
    }
  }
  
  onEdit(){
    if (this.formData!.valid) {
      console.log(this.formData!.value);
      console.log(this.tutorial);

    if(this.isEditMode){
      let element:GetAllTutorials={
        id:this.tutorialId,
        technologyId: this.tutorial.technologyId,
        tutorialCategoryId:this.tutorial.tutorialCategoryId,
        topic: this.tutorial.topic,
        description:this.tutorial.description,
        isPublished:false
      };
      console.log(element);
      this.service.putData<{message:string}>(`Technology/update-tutorial`,element).subscribe({
        next:(res)=>{
          console.log ("res",res);
          this.router.navigateByUrl('admin-dashboard');

        },error:(err)=>{
          console.log("error",err);
          
          
    
        }
      })
      
    }
  }
  }

 
}
