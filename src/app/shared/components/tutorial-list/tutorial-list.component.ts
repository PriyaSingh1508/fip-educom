import { Component, EventEmitter, Input, Output } from '@angular/core';
import { GetTechnologyTutorialDTO, TutorialCategory } from 'src/app/model';
//import { SearchPipe } from '../../pipes/search.pipe'; // Adjust the import path

@Component({
  selector: 'app-tutorial-list',
  templateUrl: './tutorial-list.component.html',
  styleUrls: ['./tutorial-list.component.css'],
  //providers: [SearchPipe], // Add the SearchFilterPipe to the providers
})
export class TutorialListComponent {
  @Input() tutorial: GetTechnologyTutorialDTO = {
    id:0,
    technologyName: "HTML",
    isPublished:false,
    imageUrl: "https://www.tutorialspoint.com/html/images/html-mini-logo.jpg",
    categories: []
  };
  @Output() itemDetailsEmitter = new EventEmitter<any>(); // Output EventEmitter
 
  searchTerm: string = '';

  emitItemDetails(topic: string, description: string): void {
    this.itemDetailsEmitter.emit({ topic, description });
  }

  
}
