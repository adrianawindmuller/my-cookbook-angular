import { environment } from '../../../environments/environment';

export class AppEnviroment {
  private recipe: string;
  private category: string;

  constructor() {
    this.recipe = `${environment.BaseUrl}/recipe`;
    this.category = `${environment.BaseUrl}/category`;
  }

  public recipeApi = {
    getRecipes: (): string => `${this.recipe}`,
    getRecipeDetailsById: (id: number): string =>
      `${this.recipe}/${id}/details`,
    getRecipeEditById: (id: number): string => `${this.recipe}/${id}`,
    postRecipe: (): string => `${this.recipe}`,
    putRecipe: (id: number): string => `${this.recipe}/${id}`,
    deleteRecipe: (id: number): string => `${this.recipe}/${id}`,
    togglefavorite: (id: number): string =>
      `${this.recipe}/${id}/toggle-favorite`,
    setRating: (id: number, rate: number): string =>
      `${this.recipe}/${id}/set-rating/${rate}`,
    filterRecipe: (name: string): string => `${this.recipe}/name/${name}`,
  };

  public categoryApi = {
    getCategories: (): string => `${this.category}`,
    getCategoryByIdWithRecipes: (id: number): string =>
      `${this.category}/${id}/recipes`,
  };
}
