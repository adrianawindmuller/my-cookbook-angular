export class RecipeDetails {
  id: number;
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
