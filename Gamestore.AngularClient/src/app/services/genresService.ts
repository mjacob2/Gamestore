import { Injectable } from '@angular/core';
import { HttpService } from './httpService';
import { GetAllGenresModel } from '../../models/GetAllGenresModel';
import { AddGenreModel } from '../../models/AddGenreModel';

@Injectable({
  providedIn: 'root',
})

export class GenresService {
  constructor(private http: HttpService) { }

  async getAllGenres(queryParameters?: string) {
    return await this.http.get<GetAllGenresModel[]>(`genres`);
  }

  async addGenre(genre: AddGenreModel) {
    return await this.http.post<AddGenreModel>(`genres/new`, genre);
  }
}
