// home.module.ts

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TutorialpageComponent } from './tutorialpage/tutorialpage.component';
// import { TutorialListComponent } from '../shared/components/tutorial-list/tutorial-list.component';
// import { SearchPipe } from '../shared/pipes/search.pipe';
import { SharedModule } from '../shared/shared.module';
import { TutorialRoutingModule } from './tutorial-routing.module';

@NgModule({
  declarations: [
    TutorialpageComponent,
    // TutorialListComponent,
    //SearchPipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    SharedModule ,
    TutorialRoutingModule
  ],
  exports: [
    TutorialpageComponent
  ],
  providers: [
    // ... services or providers if needed
  ],
})
export class TutorialsModule { }
