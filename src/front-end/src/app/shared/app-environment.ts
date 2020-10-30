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
    categoryId: (id: number): string => `${this.category}/${id}`,
  };

  public recipeApi = {
    recipe: (): string => `${this.recipe}`,
  };
}
