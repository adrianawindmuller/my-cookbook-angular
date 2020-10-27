export class Recipe {
  id: number;
  name: string;
  categoryId: number;
  rating: number;
  numberPortion: number;
  preparationTime: number;
  ingredients: string;
  preparationMode: string;
  public: boolean;
  images: string[] = [];
  favorite: boolean;
  userId: number = 1;
  constructor() {}
}
