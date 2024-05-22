import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ArticlesRoutingModule } from './articles-routing.module';
import { ArticleComponent } from './article/article.component';
import { SearchfilterPipe } from './searchfilter.pipe';
import { SharedModule } from '../shared/shared.module';
@NgModule({
  declarations: [
    ArticleComponent,
    SearchfilterPipe,
   
  ],
  imports: [
    CommonModule,
    ArticlesRoutingModule,
    FormsModule,
    SharedModule
  ],
  exports:[ArticleComponent,SearchfilterPipe]
})
export class ArticlesModule { }
