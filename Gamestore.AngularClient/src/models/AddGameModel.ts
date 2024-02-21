export interface AddGameModel {
  name: string
  gameAlias: string
  description: string
  price: number
  unitInStock: number
  discontinued: boolean
  genreId: number
  platformId: number
  publisherId: number
}
