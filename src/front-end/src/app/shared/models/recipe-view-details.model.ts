import { Difficulty } from './difficulty.enum';

export class RecipeViewDetails {
  id!: number;
  name!: string;
  categoryName!: string;
  difficulty!: Difficulty;
  numberPortion!: number;
  preparationTimeInMinutes!: number;
  ingredients!: string;
  preparationMode!: string;
  images: string[] = [];
  publicated!: boolean;
  favorite!: boolean;
  rating!: number;
}
