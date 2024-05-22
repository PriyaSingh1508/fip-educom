import { NgModule } from '@angular/core';
import { Routes, provideRouter, withComponentInputBinding } from '@angular/router';
import { RouterModule } from '@angular/router';
import { TutorialpageComponent } from './tutorialpage/tutorialpage.component';

const routes: Routes = [
  {path:'tutorial/:id',component:TutorialpageComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TutorialRoutingModule { }
