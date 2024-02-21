import { Component } from '@angular/core';
import { CurrentOrderModel } from '../../../../models/CurrentOrderModel';
import { OrdersService } from '../../../services/ordersService';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent {
  orderId: string = '';
  order?: CurrentOrderModel;
  errorMessage: string = '';
  isLoading: boolean = false;
  constructor(
    private ordersHttpService: OrdersService,
    private route: ActivatedRoute,
  ) { }

  async ngOnInit() {
    this.isLoading = true;
    this.route.params.subscribe(async (params: Params) => {
      this.orderId = params['orderId'];
    });

    await this.ordersHttpService
      .getOrderById(this.orderId)
      .then(cart => {
        this.order = cart;
        this.isLoading = false;
        console.log(this.order);
      })
      .catch(error => {
        console.log(error);
        this.isLoading = false;
        this.errorMessage = error.message;
      });
  }
}
