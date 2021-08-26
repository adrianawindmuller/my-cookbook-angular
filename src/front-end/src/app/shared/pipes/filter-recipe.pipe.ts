import { Pipe, PipeTransform } from '@angular/core';
import { Observable } from 'rxjs';
import { CardRecipe } from '../models/card-recipe.model';

@Pipe({
  name: 'filterRecipe',
})
export class FilterRecipePipe implements PipeTransform {
  transform(items: CardRecipe[], filter: any): any {
    filter = filter ? filter.toLocaleLowerCase() : null;

    return filter
      ? items.filter(
          (item) => item.name.toLocaleLowerCase().indexOf(filter) !== -1
        )
      : items;
  }
}
