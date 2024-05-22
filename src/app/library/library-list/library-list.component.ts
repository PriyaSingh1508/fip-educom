import { Component, OnInit } from '@angular/core';
import { LibraryService } from '../library.service';
import { LibraryList } from 'src/app/model';

@Component({
  selector: 'app-library-list',
  templateUrl: './library-list.component.html',
  styleUrls: ['./library-list.component.css']
})
export class LibraryListComponent implements OnInit {
  lists:LibraryList[]=[];
  filterTerm:string='';
  
  constructor(private service:LibraryService) {
   
    
  }
  ngOnInit(): void {
    this.GetData();
  }
  GetData(){
    this.service.getData<LibraryList[]>("librarylist.json").subscribe((data)=>{
      this.lists=data;},(error)=>{
        console.log(error);
      });
 
  }
  

}
