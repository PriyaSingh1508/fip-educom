import { Component, OnInit } from '@angular/core';
import { HomeService } from '../home.service';
import { Feedbacks } from 'src/app/model';
@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {
  feedbacks:Feedbacks[]=[];
  ngOnInit(): void {
    this.getData();
    
   
  }

  
  constructor(private service :HomeService) {
  }
  getData(){
    this.service.getData<Feedbacks[]>("feedback.json").subscribe((data)=>{
      this.feedbacks=data;},(error)=>{
        console.log(error);
      });

  }

}
