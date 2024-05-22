import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../material/material.module';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AddTutorialComponent } from './add-tutorial/add-tutorial.component';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { FormsModule } from '@angular/forms';
import { AddTechnologyComponent } from './add-technology/add-technology.component';
import { ViewTutorialComponent } from './view-tutorial/view-tutorial.component';
import { AdminRoutingModule } from './admin-routing.module';
import { ViewDialogComponent } from './view-dialog/view-dialog.component';
import { AddCategoryComponent } from './add-category/add-category.component';
import { EditCategoryComponent } from './edit-category/edit-category.component';
@NgModule({
  declarations: [
    AdminDashboardComponent,
    AddTutorialComponent,
    AddTechnologyComponent,
    ViewTutorialComponent,
    ViewDialogComponent,
    AddCategoryComponent,
    EditCategoryComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MaterialModule,
    CKEditorModule,
    FormsModule,
    AdminRoutingModule
  ],
  exports: [
    AdminDashboardComponent
  ]
})
export class AdminModule { }
