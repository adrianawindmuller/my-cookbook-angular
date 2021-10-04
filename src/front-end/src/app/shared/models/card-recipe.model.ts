export class CardRecipe {
  id!: number;
  name!: string;
  categoryName!: string;
  categoryId!: number;
  images: string[] = [];
  favorite!: boolean;
}
