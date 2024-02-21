import { Injectable } from '@angular/core';
import { HttpService } from './httpService';
import { GameListingModel } from '../../models/GameListingModel';
import { AddGameModel } from '../../models/AddGameModel';
import { GetGameByAlias } from '../../models/GetGameByAlias';

@Injectable({
  providedIn: 'root',
})
export class GamesService {
  constructor(private http: HttpService) { }

  async getAllGames(queryParameters?: string) {
    return await this.http.get<GameListingModel[]>(`games/?${queryParameters}`);
  }

  async addGame(game: AddGameModel) {
    return await this.http.post<AddGameModel>(`games/new`, game);
  }

  async getGameByAlias(gameAlias: string) {
    return await this.http.get<GetGameByAlias>(`games/${gameAlias}`);
  }

  async buyGame(gameAlias: string) {
    return await this.http.put<GetGameByAlias>(`games/${gameAlias}/buy`);
  }

  async deleteGameByAlias(gameAlias: string) {
    return await this.http.delete<GameListingModel>(`games/remove`, { alias: gameAlias });
  }
}
