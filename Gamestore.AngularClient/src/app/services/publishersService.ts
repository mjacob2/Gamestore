import { Injectable } from '@angular/core';
import { HttpService } from './httpService';
import { GetAllPublishersModel } from '../../models/GetAllPublishersModel';
import { AddPublisherModel } from '../../models/AddPublisherModel';
import { GetPublisherByIdModel } from '../../models/GetPublisherByIdModel';

@Injectable({
  providedIn: 'root',
})

export class PublishersService {
  constructor(private http: HttpService) { }

  async getAllPublishers(queryParameters?: string) {
    return await this.http.get<GetAllPublishersModel[]>(`publishers`);
  }

  async addPublisher(publisher: AddPublisherModel) {
    return await this.http.post<AddPublisherModel>(`publishers/new`, publisher);
  }

  async getPublisherById(publisherId: string) {
    return await this.http.get<GetPublisherByIdModel>(`publishers/${publisherId}`)
  }
}
