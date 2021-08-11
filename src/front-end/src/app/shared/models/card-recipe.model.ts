export class CardRecipe {
  id!: number;
  userId!: number;
  userName!: string;
  name!: string;
  categoryName!: string;
  images: string[] = [];
  favorite!: boolean;
}
