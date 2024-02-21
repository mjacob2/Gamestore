import { GetAllGenresModel } from "./GetAllGenresModel";
import { GetAllPlatformsModel } from "./GetAllPlatformsModel";

export interface GetGameByAlias {
  gameAlias: string;
  name: string;
  description: string;
  genres: GetAllGenresModel[];
  publisher: string;
  price: number;
  unitInStock: number;
  discontinued: boolean;
  platforms: GetAllPlatformsModel[];
}
