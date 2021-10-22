import { Difficulty } from './difficulty.enum';

export class CardRecipe {
  id!: number;
  name!: string;
  categoryName!: string;
  categoryId!: number;
  difficulty!: Difficulty;
  numberPortion!: number;
  preparationTimeInMinutes!: number;
  images: string[] = [];
  favorite!: boolean;
}
