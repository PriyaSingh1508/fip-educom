import { Component } from '@angular/core';
import { GetTechnologyTutorialDTO, ResponseModel, TechnologyDTO, TutorialCategory, TutorialItem } from 'src/app/model';
import { TutorialService } from '../tutorials.service';
import { ActivatedRoute } from '@angular/router';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-tutorialpage',
  templateUrl: './tutorialpage.component.html',
  styleUrls: ['./tutorialpage.component.css'],

})
export class TutorialpageComponent {
  
  tutorial:GetTechnologyTutorialDTO={
    id:0,
    technologyName:"HTML",
    isPublished:false,
  imageUrl:"https://www.tutorialspoint.com/html/images/html-mini-logo.jpg",
  categories:[]};
  categoryItem:any[]=[];

  
constructor(private service:TutorialService,private activatedRoute: ActivatedRoute,private sanitizer: DomSanitizer) {
 }
selectedItemId:number=0;
selectedCategoryId:number=0;
 
 currentItemIndex: number = 0;
 currentCategoryIndex:number=0;
 content:TutorialItem[]= [];
 item:any;
 techId:number=0;
ngOnInit(): void {
  this.activatedRoute.params.subscribe(params => {
    this.techId=params['id'];
    this.getTutorialsList(this.techId);
  });
}



  get showPreviousButton(): boolean {
    return this.currentItemIndex > 0;
  }

  get showNextButton(): boolean {
    if(this.currentItemIndex <this.tutorial?.categories[this.currentCategoryIndex]?.categoryItems?.length-1){
      return true;
    }
    else{
      return false;
    }
    // return this.currentItemIndex < this.content.length - 1;
    
  }
  nextCategory(){
    this.currentCategoryIndex++;
    this.currentItemIndex=0;

  }


   navigate(direction: 'previous' | 'next'): void {
    if (direction === 'previous' && this.showPreviousButton) {
      this.currentItemIndex--;
    } else if (direction === 'next' && this.showNextButton) {
      this.currentItemIndex++;
    }
     
     this.setCurrentItem();
   }
 
   private setCurrentItem(): void {
    this.item={
      topic:this.tutorial?.categories[this.currentCategoryIndex]?.categoryItems[this.currentItemIndex]?.topic,
      description:this.tutorial?.categories[this.currentCategoryIndex]?.categoryItems[this.currentItemIndex]?.description
    }
   }


 getTutorialsList(techid:number){
  this.service.getData<ResponseModel<GetTechnologyTutorialDTO>>(`Technology/get-technologies-details/${techid}`).subscribe((data)=>{
    this.tutorial=data.data;
    console.log(data);
    this.item={
      topic:data.data?.categories[0]?.categoryItems[0]?.topic,
      description:data.data?.categories[0]?.categoryItems[0]?.description
    }
  },(error)=>{
    console.log("error",error);
  })
 }
 updateBlogContent(event: any): void {
  this.item={
    topic:event.topic,
    description:event.description
  }
 
}


// Sanitize HTML content
sanitizeHtml(html: string): SafeHtml {
  return this.sanitizer.bypassSecurityTrustHtml(html);
}

}
