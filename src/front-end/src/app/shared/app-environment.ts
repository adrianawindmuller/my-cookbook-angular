import { environment } from '../../environments/environment';

export class AppEnviroment {
  private recipe: string;
  private category: string;

  constructor() {
    this.recipe = `${environment.BaseUrl}/recipe`;
    this.category = `${environment.BaseUrl}/category`;
  }

  public recipeApi = {
    get: (): string => `${this.recipe}`,
    getDetailsById: (id: number): string => `${this.recipe}/${id}/details`,
    getEditById: (id: number): string => `${this.recipe}/${id}`,
    post: (): string => `${this.recipe}`,
    put: (id: number): string => `${this.recipe}/${id}`,
    delete: (id: number): string => `${this.recipe}/${id}`,
    togglefavorite: (id: number): string =>
      `${this.recipe}/${id}/toggle-favorite`,
    setRating: (id: number, rate: number): string =>
      `${this.recipe}/${id}/set-rating/${rate}`,
  };

  public categoryApi = { get: (): string => `${this.category}` };
}
