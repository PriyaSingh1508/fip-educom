import { NgModule } from '@angular/core';
import { Routes, provideRouter, withComponentInputBinding } from '@angular/router';
import { RouterModule } from '@angular/router';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { RoleAuthGuard } from '../shared/services/role-auth.guard';
import { AddTutorialComponent } from './add-tutorial/add-tutorial.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';

const routes: Routes = [
  
  {path:'admin-dashboard',component:AdminDashboardComponent,canActivate:[RoleAuthGuard]},
  {path:'edit-tutorial/:id',component:AddTutorialComponent},
  {path:'edit-category/:id',component:EditCategoryComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule { }
