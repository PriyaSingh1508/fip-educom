import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { TopCategoriesComponent } from './top-categories/top-categories.component';
import { CategoriesBadgeComponent } from '../shared/components/categories-badge/categories-badge.component';

import { HeroComponent } from './hero/hero.component';
import { StatsComponent } from './stats/stats.component';
import { TabsComponent } from './tabs/tabs.component';
import { CodingGroundComponent } from './coding-ground/coding-ground.component';
import { HomepageComponent } from './homepage/homepage.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { ToolsComponent } from './tools/tools.component';

import { CertificationsComponent } from './certifications/certifications.component';
import { LatestCoursesComponent } from './latest-courses/latest-courses.component';
import { HomeTutorialsLibraryComponent } from './home-tutorials-library/home-tutorials-library.component';
import { SharedModule } from '../shared/shared.module';
import { HomeRoutingModule } from './home-routing.module';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    TopCategoriesComponent,
    HeroComponent,
    StatsComponent,
    TabsComponent,
    CodingGroundComponent,
    
   
    HomepageComponent,
    
    FeedbackComponent,
    ToolsComponent,
    
    HomepageComponent,
    FeedbackComponent,
    ToolsComponent,
    CertificationsComponent,
    LatestCoursesComponent,
    HomeTutorialsLibraryComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    HomeRoutingModule,
    FormsModule,
    RouterModule
   
   
  ],
  exports: [
    HomepageComponent
  ],
  providers: [
    // ... services or providers if needed
  ],
})
export class HomeModule { }
