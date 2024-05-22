import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LibrarypageComponent } from './librarypage/librarypage.component';

const routes: Routes = [
    {path:'library',component:LibrarypageComponent}
];

@NgModule({
    declarations:[],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LibraryRoutingModule { }
