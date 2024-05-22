import { Component, OnInit } from '@angular/core';
import { TutorialService } from '../../services/tutorial.service';
import { FooterItem } from 'src/app/model';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit{

 public footer!: FooterItem[];
  constructor(private service:TutorialService) {
  }
  ngOnInit(){
   this.getFooterItems();
  }

  getFooterItems(){
    this.service.getJsonData<FooterItem[]>("../../../../assets/data/footer.json").subscribe((data)=>{
      this.footer=data;
      console.log(data)
      },(error)=>{
        console.log(error);
      });
  }
}
