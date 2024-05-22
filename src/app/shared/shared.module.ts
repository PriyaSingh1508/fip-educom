import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { NavbarComponent } from "./components/navbar/navbar.component";
import { FooterComponent } from "./components/footer/footer.component";
import { NavbarMenuComponent } from "./components/navbar-menu/navbar-menu.component";
import { CategoriesBadgeComponent } from "./components/categories-badge/categories-badge.component";
import { PreHeaderComponent } from "./components/pre-header/pre-header.component";
import { MenuIconComponent } from "./components/menu-icon/menu-icon.component";
import { CourseCardComponent } from "./components/course-card/course-card.component";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { CategoryPipe } from './pipes/category.pipe';


import {MatListModule} from '@angular/material/list';
import {MatGridListModule} from '@angular/material/grid-list';
import{BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatNativeDateModule } from '@angular/material/core';
import{MatToolbarModule} from '@angular/material/toolbar';
import {MatTableModule} from '@angular/material/table'
import { MatPaginatorModule} from '@angular/material/paginator';
import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatButtonModule} from '@angular/material/button';
import {NgFor, AsyncPipe} from '@angular/common';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatRadioModule} from '@angular/material/radio';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatIconModule} from '@angular/material/icon';

import { TutorialListComponent } from "./components/tutorial-list/tutorial-list.component";
import { SearchPipe } from "./pipes/search.pipe";
@NgModule({
    declarations: [
      
      NavbarComponent,
      FooterComponent,
      NavbarMenuComponent,
      PreHeaderComponent,
      CategoriesBadgeComponent,
      MenuIconComponent,
      CourseCardComponent,
      CategoryPipe,
      TutorialListComponent,
      SearchPipe
    ],
    imports: [
      CommonModule,
      FormsModule ,
      RouterModule,
      BrowserAnimationsModule
     
    ],
    exports: [
        NavbarComponent,
      FooterComponent,
      NavbarMenuComponent,
      PreHeaderComponent,
      CategoriesBadgeComponent,
      MenuIconComponent,
      CourseCardComponent,
      CategoryPipe,
      MatPaginatorModule,
    MatCardModule,
    MatListModule,
    MatGridListModule,
    MatIconModule,
    MatRadioModule,
    MatAutocompleteModule,
    MatInputModule,
    MatFormFieldModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatSelectModule,
    MatNativeDateModule,
    MatButtonModule,
    MatSidenavModule,
    MatToolbarModule,
    MatTableModule,
      
      MatCardModule,
      MatInputModule,
      MatFormFieldModule,
      MatRadioModule,
      MatCheckboxModule,
      MatDatepickerModule,
      MatSelectModule,
      MatIconModule,
      MatButtonModule,
      MatAutocompleteModule,
      NgFor, AsyncPipe,
      MatSidenavModule,
      TutorialListComponent,
     SearchPipe
    ],
    providers: [
      // ... services or providers if needed
    ],
  })
  export class SharedModule { }