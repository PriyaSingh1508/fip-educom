import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LibraryListComponent } from './library-list/library-list.component';
import { TopCategoryComponent } from './top-category/top-category.component';
import { SharedModule } from '../shared/shared.module';
import { CategoryCardComponent } from './category-card/category-card.component';
import { LibrarypageComponent } from './librarypage/librarypage.component';
import { LibraryRoutingModule } from './library-routing.module';
import { LibraryService } from './library.service';
import { FormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    LibraryListComponent,
    TopCategoryComponent,
    CategoryCardComponent,
    LibrarypageComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    LibraryRoutingModule,
    FormsModule
  ],
  exports:[LibrarypageComponent],
  providers:[LibraryService]
})
export class LibraryModule { }
