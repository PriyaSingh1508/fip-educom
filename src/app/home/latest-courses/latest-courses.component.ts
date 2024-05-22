import { Component } from '@angular/core';

@Component({
  selector: 'app-latest-courses',
  templateUrl: './latest-courses.component.html',
  styleUrls: ['./latest-courses.component.css']
})
export class LatestCoursesComponent {
  selectedTab: string = 'mostpopular';

  selectTab(tab: string): void {
    this.selectedTab = tab;
  }
}
