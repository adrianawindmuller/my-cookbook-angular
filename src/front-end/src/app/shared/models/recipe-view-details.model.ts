export class RecipeViewDetails {
  id!: number;
  name!: string;
  categoryName!: string;
  numberPortion!: number;
  preparationTimeInMinutes!: number;
  ingredients!: string;
  preparationMode!: string;
  images: string[] = [];
  publicated!: boolean;
  favorite!: boolean;
  rating!: number;
}
