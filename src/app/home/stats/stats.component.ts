import { Component,Input } from '@angular/core';

@Component({
  selector: 'app-stats',
  templateUrl: './stats.component.html',
  styleUrls: ['./stats.component.css']
})
export class StatsComponent {
  @Input() icon: string = 'fa-chalkboard-user'; 
  @Input() backgroundColor: string = '#007BFF';
  @Input() statsNumber: string = '0';
  @Input() statsTitle: string = 'Stats';
}
