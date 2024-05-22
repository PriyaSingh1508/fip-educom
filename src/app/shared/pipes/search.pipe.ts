import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchFilter'
})
export class SearchPipe implements PipeTransform {

  transform(items: any[], searchTerm: string): any[] {
    if (!items || !searchTerm) {
      return items;
    }

    searchTerm = searchTerm.toLowerCase();

    return items
      .filter(item =>
        item.categoryName.toLowerCase().includes(searchTerm) ||
        item.categoryItems.some((listItem: { id: number,topic: string, }) => listItem.topic.toLowerCase().includes(searchTerm))
      )
      .map(filteredItem => ({
        categoryName: filteredItem.categoryName,
        categoryItems: filteredItem.categoryItems.filter(
          (          listItem: { topic: string; }) => listItem.topic.toLowerCase().includes(searchTerm)
        ),
      }));
  }

}
