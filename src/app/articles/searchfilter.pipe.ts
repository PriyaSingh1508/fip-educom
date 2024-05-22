import { Pipe, PipeTransform } from '@angular/core';
import { ArticleCategoryItem } from '../model';

@Pipe({
  name: 'searchfilter'
})
export class SearchfilterPipe implements PipeTransform {

  transform(categoryList: ArticleCategoryItem[], searchText: string): any {
    if (!searchText) {
      return categoryList;
    }
    return categoryList.filter(category => category.title.toLowerCase().includes(searchText.toLowerCase()));

  }

}
