import { Pipe, PipeTransform } from '@angular/core';
import {  LibraryList } from 'src/app/model';

@Pipe({
  name: 'category'
})
export class CategoryPipe implements PipeTransform {

  transform(lists: LibraryList[], filterTerm: string): LibraryList[] {

    if (!filterTerm) {
      return lists;
    }
    return lists.filter((list)=>list.categoryName.toLowerCase().includes(filterTerm.toLowerCase())|| list.items.some(item=>item.name.toLowerCase().includes(filterTerm.toLowerCase())))
   
  }

}
