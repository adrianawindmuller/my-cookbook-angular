import { environment } from '../../environments/environment';

export class AppEnviroment {
  private category: string;

  constructor() {
    this.category = `${environment.BaseUrl}/category`;
  }

  public categoryApi = {
    category: (): string => `${this.category}`,
  };
}
