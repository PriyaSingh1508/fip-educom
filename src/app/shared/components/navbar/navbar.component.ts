import { Component } from '@angular/core';
import { TokenHandlerService } from '../../services/token-handler.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
public user:any;
constructor(private router:Router,private tokenService:TokenHandlerService){}

isLoggedIn() {
  const token = this.tokenService.getToken();
  if (token) {
      this.user = token.email;
      return true;
  } else {
      this.user = null;
      return false;
  }
}


  logout(){
    sessionStorage.clear();
    this.router.navigate(['/login']);
  }

}
