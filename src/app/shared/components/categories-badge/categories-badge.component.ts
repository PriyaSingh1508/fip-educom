import { Component,Input } from '@angular/core';

@Component({
  selector: 'app-categories-badge',
  templateUrl: './categories-badge.component.html',
  styleUrls: ['./categories-badge.component.css']
})
export class CategoriesBadgeComponent {
  @Input() categoryTitle: string = 'Programming'; // Default stats title
  @Input() numberOfCourses: string = '38'; // Default stats title
  @Input() categoryIcon: string = 'fa-code'; // Default stats title
  @Input() categoryColor: string = '#04af2f';
}
