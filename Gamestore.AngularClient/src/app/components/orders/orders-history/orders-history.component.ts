import { Component } from '@angular/core';
import { OrdersService } from '../../../services/ordersService';
import { OrdersHistoryListingModel } from '../../../../models/OrdersHistoryListingModel';
import { MatTableDataSource } from '@angular/material/table';
import { DisplayedFilters } from '../../shared/filtering-options/displayedFilters';

@Component({
  selector: 'app-orders-history',
  templateUrl: './orders-history.component.html',
  styleUrls: ['./orders-history.component.css']
})
export class OrdersHistoryComponent {
  isLoading: boolean = false;
  errorMessage: string = '';
  dataSource = new MatTableDataSource<OrdersHistoryListingModel>
  displayedColumns = [
    'id',
    'orderDate',
    'customerId',
  ];
  filterQueryParameters: string = '';

  displayedFilters: DisplayedFilters = {
    dateRange: true,
  };

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
    const queryParameters = this.filterQueryParameters;
    this.isLoading = true;
    try {
      this.dataSource.data = await this.ordersHttpService.getOrdersHistory(queryParameters);
      this.isLoading = false;
    } catch (error: any) {
      this.isLoading = false;
      this.errorMessage = error.message
    }
  }

  onFilter(queryParameters: string) {
    console.log(queryParameters)
    this.filterQueryParameters = queryParameters;
    this.getTableDataSource();
  }
}
