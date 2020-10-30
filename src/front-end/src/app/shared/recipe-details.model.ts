export class RecipeDetails {
  recipeId: number;
  recipeName: string;
  categoryName: number;
  numberPortion: number;
  preparationTimeInMinutes: number;
  ingredients: string;
  preparationMode: string;
  images: string[] = [];
  favorite: boolean;
  rating: number;
}
