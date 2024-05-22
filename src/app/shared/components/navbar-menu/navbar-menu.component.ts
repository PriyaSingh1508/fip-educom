import { Component, OnInit } from '@angular/core';
import { TutorialService } from '../../services/tutorial.service';
import { ResponseModel, TechnologyDTO } from 'src/app/model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar-menu',
  templateUrl: './navbar-menu.component.html',
  styleUrls: ['./navbar-menu.component.css']
})
export class NavbarMenuComponent implements OnInit {
  tutorials:TechnologyDTO[]=[];
  selectedMenu:string="";
  constructor(private service:TutorialService, private route:Router) {
    
    
  }


 ngOnInit(): void {

  this.getTutorials();
   
 }
 getTutorials(){
  this.service.getData<ResponseModel<TechnologyDTO[]>>('Technology/get-publishedtechnologies').subscribe((data)=>{
    console.log(data);
    
    this.tutorials=data.data;
    

    },(error)=>{
      console.log(error);
    })
 }
 getTechnologyById(id:number,itemName:string){
  this.route.navigate(['tutorial', id]);
  this.selectedMenu=itemName;
 }
 scrollMenu(offset: number): void {
    const scrollableMenu = document.querySelector('.scrollable-menu') as HTMLElement;
    scrollableMenu.scrollLeft += offset;
  }
}
