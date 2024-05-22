import { Component, OnInit} from '@angular/core';
import { HomeService } from '../home.service';
import { TutorialsLibrary } from 'src/app/model';

@Component({
  selector: 'app-home-tutorials-library',
  templateUrl: './home-tutorials-library.component.html',
  styleUrls: ['./home-tutorials-library.component.scss']
})

export class HomeTutorialsLibraryComponent  {
 tutorialsLibrary: TutorialsLibrary[] = [];   
  constructor(private homeService: HomeService) {}   
  ngOnInit(): void {
    this.getTutorials();
  }
  
  getTutorials() {
    this.homeService.getData<TutorialsLibrary[]>("hometutorials.json").subscribe((data) => { 
      this.tutorialsLibrary = data;
     });}

  currentPage = 1;
  itemsPerPage = 4;
get totalPages(): number {
  return Math.ceil(this.tutorialsLibrary.length / this.itemsPerPage);
}
 
get paginatedTutorials(): TutorialsLibrary[] {
  const startIndex = (this.currentPage - 1) * this.itemsPerPage;
  return this.tutorialsLibrary.slice(startIndex, startIndex + this.itemsPerPage);
}
 
onPreviousPage(): void {
  if (this.currentPage > 1) {
    this.currentPage--;
  }
}
 
onNextPage(): void {
  if (this.currentPage < this.totalPages) {
    this.currentPage++;
  }
}

 
  
}
