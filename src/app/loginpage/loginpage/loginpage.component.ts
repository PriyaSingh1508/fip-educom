import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginpageService } from '../loginpage.service';
import { Login } from 'src/app/model';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-loginpage',
  templateUrl: './loginpage.component.html',
  styleUrls: ['./loginpage.component.css']
})
export class LoginpageComponent {
  email: string="";
  password: string="";
  errorMessage: string="";
  isLoading=false;
  constructor(private router: Router,private service:LoginpageService,private _snackBar: MatSnackBar) {}

  login(): void {
    // if (this.email === 'admin@example.com' && this.password === 'admin123') {
    //   this.router.navigate(['/admin-dashboard']);
    // } else if (this.email === 'teacher@example.com' && this.password === 'teacher123') {
    //   this.router.navigate(['/teacher-dashboard']);
    // } else if (this.email === 'student@example.com' && this.password === 'student123') {
    //   this.router.navigate(['/student-dashboard']);
    // } else {
    //   this.errorMessage = 'Invalid email or password';
    // }

    let login:Login={
      email:this.email,
      password:this.password
    }
    this.service.postData<any>("Account/login",login).subscribe({
      next:(res)=>{
        this.isLoading=true;
        
        
        let data:any=res;
         this._snackBar.open("LoggedIn successfully!!", "close",{
          duration: 4000
        });
        
        this.service.setToken(data);
        this.isLoading=false;
        if(data.role=="Student"){
          this.router.navigate(['/student-dashboard']);
        }
        else if(data.role=="Teacher"){
          this.router.navigate(['/teacher-dashboard']);

        } else if(data.role=="Admin"){
          this.router.navigate(['/admin-dashboard']);

        }
        else{
          this.router.navigate(['/']);
        }

        
      
      },error:(err)=>{
        this._snackBar.open("Email or Password is invalid!!", "close",{
          duration: 4000
        });
        this.isLoading=false;
       

      }
    });

  }
}
