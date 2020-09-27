import { ImagePath } from './step/step-advanced/imagePath.model';

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
  imagemPath: string[] = [];
  favorite: boolean;
  constructor() {}
}
