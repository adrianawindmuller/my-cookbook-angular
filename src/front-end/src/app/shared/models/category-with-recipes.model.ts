import { CardRecipe } from './card-recipe.model';

export class CategoryWithRecipes {
  id!: number;
  name!: string;
  numberOfRecipes!: number;
  icon!: string;
  recipes: CardRecipe[] = [];
}
