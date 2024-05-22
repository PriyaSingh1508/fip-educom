import { Component } from '@angular/core';
import { NgIf } from '@angular/common';
import { Router } from '@angular/router';
import { TokenHandlerService } from 'src/app/shared/services/token-handler.service';
@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent {
  showFiller = false;
  selectedMenu: string = 'viewTutorials';
  constructor(private router:Router, private tokenService:TokenHandlerService){
    // const data=tokenService.getToken();
    // if(data=="" || data.role!="Admin")
    // {
    //   this.router.navigate(['/login']);
    // }
  }
  selectMenu(tab: string): void {
    this.selectedMenu = tab;
  }

  logout(){
    sessionStorage.clear();
    this.router.navigate(['/login']);
  }
}
