import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import{HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { HomeModule } from './home/home.module';
import { TutorialsModule } from './tutorials/tutorials.module';
import { AdminModule } from './admin/admin.module';
import { LibraryModule } from './library/library.module';
import { SharedModule } from './shared/shared.module';


import { ArticlesModule } from './articles/articles.module';
import { TeacherModule } from './teacher/teacher.module';
import { CommonHttpService } from './shared/services/common-http.service';
import { LoginPageModule } from './loginpage/loginpage.module';
import { StudentModule } from './student/student.module';
import { TokenInterceptor } from './shared/interceptors/token.interceptor';


@NgModule({
  declarations: [
    AppComponent
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HomeModule,
    ArticlesModule,
    TeacherModule,
    HttpClientModule,
    TutorialsModule,
    AdminModule,
    LibraryModule,
    SharedModule,
    LoginPageModule,
    StudentModule,
 
  ],
  providers: [CommonHttpService,
    {
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,multi:true
  }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
