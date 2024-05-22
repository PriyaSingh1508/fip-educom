import { Component, Input,EventEmitter,Output, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';

@Component({
  selector: 'app-category-card',
  templateUrl: './category-card.component.html',
  styleUrls: ['./category-card.component.css']
})
export class CategoryCardComponent implements OnChanges {
  @Input() id:number=1;
  @Input() categoryName:string='Python Technologies';
  @Input() imageUrl:string='https://www.tutorialspoint.com/images/python_icon.svg';
  @Input() link:string='#';
  @Output() showDataEvent= new EventEmitter();

  displayData(){
    this.showDataEvent.emit(this.id);


  }
  changeLog:string[]=[];
  ngOnChanges(changes: SimpleChanges): void {
   console.log(changes);
  
    
  }


}
