import { NgModule } from '@angular/core';
import { Routes } from '@angular/router';
import { TeacherFormComponent } from './teacher-form/teacher-form.component';
import { RouterModule } from '@angular/router';
import { DashboardSidenavComponent } from './dashboard-sidenav/dashboard-sidenav.component';
import { TeacherDashboardComponent } from './teacher-dashboard/teacher-dashboard.component';
import { UpdateContentComponent } from './update-content/update-content.component';
import { ViewContentDetailsComponent } from './view-content-details/view-content-details.component';
import { RoleAuthGuard } from '../shared/services/role-auth.guard';

const routes: Routes = [
  {path:'add-teacher',component:TeacherFormComponent,canActivate:[RoleAuthGuard]},
  {path:'teacher-dashboard',component:DashboardSidenavComponent,
       children:[ { path: '', component: TeacherDashboardComponent }, 
            {path: "edit-record/:id", component: UpdateContentComponent},
              {path:"view-record/:id", component:ViewContentDetailsComponent},],canActivate:[RoleAuthGuard]
},

 // { path: '', redirectTo: '/teacher-dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TeacherRoutingModule { }
