export class RecipeViewDetails {
  recipeId: number;
  nameRecipe: string;
  categoryName: string;
  numberPortion: number;
  preparationTimeInMinutes: number;
  ingredients: string;
  preparationMode: string;
  images: string[] = [];
  userId: number;
  publicated: boolean;
  favorite: boolean;
  rating: number;
}
