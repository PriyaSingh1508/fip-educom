import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-course-card',
  templateUrl: './course-card.component.html',
  styleUrls: ['./course-card.component.css']
})
export class CourseCardComponent {
  @Input() imageUrl: string = 'https://www.tutorialspoint.com/static/images/home/business-analytics-certification.jpg';
  @Input() title: string = 'Business Analytics Certifications';
  @Input() provider: string = 'TutorialPoint';
  @Input() author: string = 'TutorialPoint';
  @Input() isCourse: boolean = false;
  @Input() isFree: boolean = false;
  @Input() isEbook: boolean = false;
  @Input() numberOfCourses: string="6";
  @Input() numberOfLectures: string="5";
  @Input() numberOfBooks: string="1";
}
