import { Component } from '@angular/core';

@Component({
  selector: 'app-certifications',
  templateUrl: './certifications.component.html',
  styleUrls: ['./certifications.component.css']
})
export class CertificationsComponent {
  selectedTab: string = 'mostpopular';

  selectTab(tab: string): void {
    this.selectedTab = tab;
  }
}
