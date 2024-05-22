import { Component,Input } from '@angular/core';

@Component({
  selector: 'app-menu-icon',
  templateUrl: './menu-icon.component.html',
  styleUrls: ['./menu-icon.component.css']
})
export class MenuIconComponent {
  @Input() menuTitle: string = 'Python Tutorial'; 
  @Input() menuIcon: string='https://www.tutorialspoint.com/static/images/home/python-library-icon.svg';
}
