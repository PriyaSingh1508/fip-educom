import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddStudentComponent } from './add-student/add-student.component';
import { StudentDashboardComponent } from './student-dashboard/student-dashboard.component';
import { RoleAuthGuard } from '../shared/services/role-auth.guard';

const routes: Routes = [
  {path:'add-student',component:AddStudentComponent},
  {path:'student-dashboard',component:StudentDashboardComponent,canActivate:[RoleAuthGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentRoutingModule { }
