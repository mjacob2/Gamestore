import { Component } from '@angular/core';
import { CurrentOrderModel } from '../../../../models/CurrentOrderModel';
import { MatTableDataSource } from '@angular/material/table';
import { OrdersService } from '../../../services/ordersService';

@Component({
  selector: 'app-orders-table',
  templateUrl: './orders-table.component.html',
  styleUrls: ['./orders-table.component.css']
})
export class OrdersTableComponent {
  isLoading: boolean = false;
  errorMessage: string = '';
  dataSource = new MatTableDataSource<CurrentOrderModel>
  displayedColumns = [
    'status',
    'id',
    'orderDate',
    'paidDate',
    'sum',
    'totalPrice'
  ];

  constructor(
    private ordersHttpService: OrdersService,
  ) { }


  async ngOnInit() {
    this.isLoading = true;
    try {
      await this.getTableDataSource();
      this.isLoading = false;
    } catch (error: any) {
      this.isLoading = false;
      this.errorMessage = error.message
    }
  }

  private async getTableDataSource(): Promise<void> {
    this.dataSource.data = await this.ordersHttpService.getAllOrders();
    console.log(this.dataSource.data);
  }
}
