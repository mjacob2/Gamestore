import { Injectable } from '@angular/core';
import { HttpService } from './httpService';
import { CurrentOrderModel } from '../../models/CurrentOrderModel';
import { OrdersHistoryListingModel } from '../../models/OrdersHistoryListingModel';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  constructor(private http: HttpService) { }

  async getCurrentOrder(queryParameters?: string) {
    return await this.http.get<CurrentOrderModel>(`cart`);
  }

  async getAllOrders(queryParameters?: string) {
    return await this.http.get<CurrentOrderModel[]>(`orders`);
  }

  async getOrdersHistory(queryParameters?: string) {
    return await this.http.get<OrdersHistoryListingModel[]>(`orders/history/?${queryParameters}`);
  }

  async getOrderById(orderId: string) {
    return await this.http.get<CurrentOrderModel>(`orders/${orderId}`)
  }

  async payForOrderBankPaymentMethod(queryParameters?: string) {
    return await this.http.get<CurrentOrderModel>(`orders/pay/bank`)
  }

  async payForOrderIbox() {
    return await this.http.post(`orders/pay/ibox`);
  }

  async payForOrderVisa() {
    return await this.http.post(`orders/pay/visa`);
  }
}
