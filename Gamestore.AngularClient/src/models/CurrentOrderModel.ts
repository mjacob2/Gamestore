import { OrderItemModel } from "./OrderItemModel";

export interface CurrentOrderModel {
  id: number;
  customerId: string;
  orderDate: Date;
  paidDate: Date;
  sum: number;
  discount: number;
  totalPrice: number;
  status: string;
  orderItems: OrderItemModel[];
}
