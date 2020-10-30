export class Recipe {
  id: number;
  name: string;
  categoryId: number;
  userId: number = 1;
  rating: number;
  numberPortion: number;
  preparationTime: number;
  ingredients: string;
  preparationMode: string;
  public: boolean;
  images: string[] = [];
  favorite: boolean;
}
