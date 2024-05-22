import { Component } from '@angular/core';

@Component({
  selector: 'app-tabs',
  templateUrl: './tabs.component.html',
  styleUrls: ['./tabs.component.css']
})
export class TabsComponent {
  selectedTab: string = 'library';

  selectTab(tab: string): void {
    this.selectedTab = tab;
  }

  
}
