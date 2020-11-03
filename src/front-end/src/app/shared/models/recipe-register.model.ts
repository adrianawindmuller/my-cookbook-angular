export class RecipeRegister {
  id: number;
  name: string;
  categoryId: number;
  userId: number;
  numberPortion: number;
  preparationTimeInMinutes: number;
  ingredients: string;
  preparationMode: string;
  images: string[] = [];
  publicated: boolean;
}
