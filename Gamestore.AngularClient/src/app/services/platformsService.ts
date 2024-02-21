import { Injectable } from '@angular/core';
import { HttpService } from './httpService';
import { GetAllPlatformsModel } from '../../models/GetAllPlatformsModel';
import { AddPlatformModel } from '../../models/AddPlatformModel';

@Injectable({
  providedIn: 'root',
})

export class PlatformsService {
  constructor(private http: HttpService) { }

  async getAllPlatforms(queryParameters?: string) {
    return await this.http.get<GetAllPlatformsModel[]>(`platforms`);
  }

  async addPlatform(platform: AddPlatformModel) {
    return await this.http.post<AddPlatformModel>(`platforms/new`, platform);
  }
}
