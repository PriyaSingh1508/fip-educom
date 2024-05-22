import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginpageComponent } from './loginpage/loginpage.component';
import { LoginPageRoutingModule } from './loginpage-routing.module';
import { MaterialModule } from '../material/material.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    LoginpageComponent
  ],
  imports: [
    CommonModule,
    LoginPageRoutingModule,
    MaterialModule,
    FormsModule
  ],
  exports:[
    LoginpageComponent
  ]
})
export class LoginPageModule { }
