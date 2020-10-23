export class Recipe {
  id: number;
  name: string;
  category: string;
  rating: number;
  numberPortion: number;
  preparationTime: number;
  ingredients: string;
  preparationMode: string;
  public: boolean;
  images: string[] = [];
  favorite: boolean;
  constructor() {}
}
