export interface GameListingModel {
  gameAlias: string;
  name: string;
  genresNames: string[];
  publisher: string;
  platform: string;
  price: number;
  unitInStock: number;
  discontinued: boolean;
  publishDate: Date;
  viewCount: number;
}
