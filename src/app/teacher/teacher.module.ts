import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeacherRoutingModule } from './teacher-routing.module';
import { TeacherFormComponent } from './teacher-form/teacher-form.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { TeacherDashboardComponent } from './teacher-dashboard/teacher-dashboard.component';
import { DashboardSidenavComponent } from './dashboard-sidenav/dashboard-sidenav.component';
import { UpdateContentComponent } from './update-content/update-content.component';
import { ViewContentDetailsComponent } from './view-content-details/view-content-details.component';
@NgModule({
  declarations: [
    TeacherFormComponent,
    TeacherDashboardComponent,
    DashboardSidenavComponent,
    UpdateContentComponent,
    ViewContentDetailsComponent
  ],
  imports: [
    CommonModule,
    TeacherRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ],
  exports:[
    TeacherFormComponent
  ]
})
export class TeacherModule { }
