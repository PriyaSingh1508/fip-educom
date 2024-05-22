import { Component, OnInit } from '@angular/core';
import { HomeService } from '../home.service';
import { Tools } from 'src/app/model';
@Component({
  selector: 'app-tools',
  templateUrl: './tools.component.html',
  styleUrls: ['./tools.component.css']
})
export class ToolsComponent implements OnInit {
  tools:Tools[]=[];
 constructor(private service:HomeService) {

    
    
  }
  ngOnInit(): void {
    this.getData();
   
    
  }
  getData(){

    this.service.getData<Tools[]>("tools.json").subscribe((data)=>{
      this.tools=data;
    },(error)=>{
      console.log("error");
    });
  }
 
  
}
