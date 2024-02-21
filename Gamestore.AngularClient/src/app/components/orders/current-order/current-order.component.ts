import { Component } from '@angular/core';
import { OrdersService } from '../../../services/ordersService';
import { ActivatedRoute, Params } from '@angular/router';
import { CurrentOrderModel } from '../../../../models/CurrentOrderModel';

@Component({
  selector: 'app-current-order',
  templateUrl: './current-order.component.html',
  styleUrls: ['./current-order.component.css']
})
export class CurrentOrderComponent {
  alias: string = '';
  cart?: CurrentOrderModel;
  errorMessage: string = '';
  isLoading: boolean = false;

  constructor(
    private ordersHttpService: OrdersService,
    private route: ActivatedRoute,
  ) { }


  async ngOnInit() {
    this.isLoading = true;
    this.route.params.subscribe(async (params: Params) => {
      this.alias = params['gameAlias'];
    });

    await this.ordersHttpService
      .getCurrentOrder()
      .then(cart => {
        this.cart = cart;
        this.isLoading = false;
        console.log(this.cart);
      })
      .catch(error => {
        this.isLoading = false;
        this.errorMessage = error.message;
      });
  }
}
