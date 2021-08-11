export class SaveRecipe {
  id!: number;
  name!: string;
  categoryId!: number;
  userId!: number;
  numberPortion!: number;
  preparationTimeInMinutes!: number;
  ingredients!: string;
  preparationMode!: string;
  images: string[] = [];
  published!: boolean;
}
