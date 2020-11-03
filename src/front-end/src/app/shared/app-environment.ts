import { environment } from '../../environments/environment';

export class AppEnviroment {
  private category: string;
  private recipe: string;

  constructor() {
    this.category = `${environment.BaseUrl}/category`;
    this.recipe = `${environment.BaseUrl}/recipe`;
  }

  public categoryApi = {
    category: (): string => `${this.category}`,
  };

  public recipeApi = {
    recipe: (): string => `${this.recipe}`,
    recipeId: (id: number): string => `${this.recipe}/${id}/details`,
    recipeIdEdit: (id: number): string => `${this.recipe}/${id}`,

    registerRecipe: (): string => `${this.recipe}`,

    toggleFavorite: (id: number): string =>
      `${this.recipe}/${id}/toggle-favorite`,

    setRating: (id: number, rate: number): string =>
      `${this.recipe}/${id}/set-rating/${rate}`,
  };
}
