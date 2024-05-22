import { Component, DoCheck, OnChanges, OnInit, SimpleChange, SimpleChanges } from '@angular/core';
import { CategoryContent, TopCategory } from 'src/app/model';
import { LibraryService } from '../library.service';

@Component({
  selector: 'app-top-category',
  templateUrl: './top-category.component.html',
  styleUrls: ['./top-category.component.css'],
  
})
export class TopCategoryComponent implements OnInit,DoCheck {
  
  categories:TopCategory[]=[];
  categoryContent:CategoryContent[]=[];
  id:number=1;
  ngOnInit(): void {

    this.getData();
    this.getContentById();
  }
  
  constructor(private service:LibraryService) {
    
  }
  ngDoCheck(): void {
   console.log("docheck");
  }
 
 

 getData(){
    this.service.getData<TopCategory[]>("category.json").subscribe((data)=>{
      this.categories=data;},(error)=>{
        console.log(error);
      });

  }
  getContentById(){
    console.log(this.id);
    this.service.getData<CategoryContent[]>("categorycontent.json").subscribe((data)=>{
      this.categoryContent=data.filter(obj=>obj.categoryId==this.id);},(error)=>{
        console.log(error);
      });
    

  }
  displayData(){
    this.getContentById();
  }
  getEventData(id:number){
    this.id=id;
  }



}
